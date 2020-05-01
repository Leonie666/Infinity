using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


[TaskCategory("Custom")]
//[TaskIcon("Assets/Behavior Designer/Runtime/Tasks/Custom/PointPatrolIconN.png")]
[TaskDescription("Allows Object to move from point to point in order or randomly.")]
public class CanSeeObject : Conditional
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("The object that we are searching for")]
    public SharedGameObject targetObject;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("The field of view angle of the agent (in degrees)")]
    public SharedFloat fieldOfViewAngle = 30;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("The distance that the agent can see")]
    public SharedFloat viewDistance = 3;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("The object that is within sight")]
    public SharedGameObject returnedObject;


    /// <summary>
    /// Returns success if an object was found otherwise failure
    /// </summary>
    public override TaskStatus OnUpdate()
    {
        returnedObject.Value = WithinSight(targetObject.Value, fieldOfViewAngle.Value, viewDistance.Value);

        return returnedObject.Value != null ? TaskStatus.Success : TaskStatus.Failure; // Object found return Success, not found within sight return Failure
    }


    /// <summary>
    /// Determines if the targetObject is within sight of the transform.
    /// </summary>
    private GameObject WithinSight(GameObject targetObject, float fieldOfViewAngle, float viewDistance)
    {
        if (targetObject == null) return null;

        var sightDirection = targetObject.transform.position - transform.position;
        sightDirection.y = 0;
        var angle = Vector3.Angle(sightDirection, transform.forward);

        if (sightDirection.magnitude < viewDistance && angle < fieldOfViewAngle * 0.5f) // The hit agent needs to be within view of the current agent
            if (LineOfSight(targetObject)) return targetObject; // return the target object meaning it is within sight

        return null;
    }


    /// <summary>
    /// Returns true if the target object is within the line of sight.
    /// </summary>
    private bool LineOfSight(GameObject targetObject)
    {
        if (Physics.Linecast(transform.position, targetObject.transform.position, out RaycastHit hit))
            if (hit.transform.IsChildOf(targetObject.transform) ||
                targetObject.transform.IsChildOf(hit.transform)) return true;

        return false;
    }



    public override void OnDrawGizmos()
    {
#if UNITY_EDITOR
        var oldColor = UnityEditor.Handles.color;
        var color = Color.yellow;
        color.a = 0.1f;
        UnityEditor.Handles.color = color;

        var halfFOV = fieldOfViewAngle.Value * 0.5f;
        var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
        UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, viewDistance.Value);

        UnityEditor.Handles.color = oldColor;
#endif
    }
}
