using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Custom")]
//[TaskIcon("Assets/Behavior Designer/Runtime/Tasks/Custom/PointPatrolIconN.png")]
[TaskDescription("Change Object's agent MovementSpeed on navmesh")]
public class ChangeNavMeshSpeed : Action
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("The object which contains a navmeshagent")]
    public SharedGameObject targetGameObject;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("new movementspeed to apply to the navmesh agent of the selected ")]
    public SharedFloat newMovementSpeed;

    private NavMeshAgent navMeshAgent;


    public override void OnStart()
    {
        var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
        navMeshAgent = currentGameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = newMovementSpeed.Value;
    }


    public override TaskStatus OnUpdate()
    {
        return navMeshAgent ? TaskStatus.Success : TaskStatus.Failure;
    }
}
