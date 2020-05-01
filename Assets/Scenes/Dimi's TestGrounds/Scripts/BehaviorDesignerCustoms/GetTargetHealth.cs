using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Custom")]
//[TaskIcon("Assets/Behavior Designer/Runtime/Tasks/Custom/PointPatrolIconN.png")]
[TaskDescription("Returns target's health if it uses any component of the following:\n\rPlayerMovement, BehaviourTree")]
public class GetTargetHealth : Conditional
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("The object that we are searching for")]
    public SharedGameObject targetObject;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("returned value of health variable")]
    public SharedInt storeHealthResult;

    /// <summary>
    /// Returns success if health is found on target
    /// </summary>
    public override TaskStatus OnUpdate()
    {
        if (targetObject.Value.GetComponent<PlayerMovement>())
        {
            storeHealthResult = targetObject.Value.GetComponent<PlayerMovement>().health;
            return TaskStatus.Success;
        }

        if (targetObject.Value.GetComponent<BehaviorTree>())
        {
            storeHealthResult.Value = int.Parse(targetObject.Value.GetComponent<BehaviorTree>().GetVariable("health").ToString());
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
