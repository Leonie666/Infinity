using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Custom")]
[TaskIcon("Assets/Behavior Designer/Runtime/Tasks/Custom/PointPatrolIconN.png")]
[TaskDescription("Allows Object to move from point to point in order or randomly.")]
public class PointPatrol : Conditional
{
    //[BehaviorDesigner.Runtime.Tasks.Tooltip("All the Points the object shall patrol to")]
    //public GameObject[] points;
    //public float speed;
    //public float angularSpeed;
    //public bool isRandomPointPatrol;

    public float fieldOfViewAngle;
    public string targetTag;
    public SharedTransform target;

    public Transform[] possibleTargets;

    public override void OnAwake()
    {
        var targets = GameObject.FindGameObjectsWithTag(targetTag);
        possibleTargets = new Transform[targets.Length];
        for (int i = 0; i < targets.Length; ++i)
        {
            possibleTargets[i] = targets[i].transform;
        }
    }

    public override TaskStatus OnUpdate()
    {
        for (int i = 0; i < possibleTargets.Length; ++i)
        {
            if (pointPatrol(possibleTargets[i], fieldOfViewAngle))
            {
                target.Value = possibleTargets[i];
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }

    public bool pointPatrol(Transform targetTransform, float fieldOfViewAngle)
    {
        Vector3 direction = targetTransform.position - transform.position;
        return Vector3.Angle(direction, transform.forward) < fieldOfViewAngle;
    }

    //public override void OnDrawGizmos()
    //{
    //    var oldColor = UnityEditor.Handles.color;
    //    var color = Color.yellow;
    //    color.a = 0.1f;
    //    UnityEditor.Handles.color = color;

    //    var halfFOV = fieldOfViewAngle.Value * 0.5f;
    //    var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
    //    UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, viewDistance.Value);

    //    UnityEditor.Handles.color = oldColor;
    //}
}