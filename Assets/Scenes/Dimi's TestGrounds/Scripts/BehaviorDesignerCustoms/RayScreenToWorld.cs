using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Custom")]
//[TaskIcon("Assets/Behavior Designer/Runtime/Tasks/Custom/PointPatrolIconN.png")]
[TaskDescription("Returns the mouseposition in world (throws ray from camera mouse pos to world)")]
public class RayScreenToWorld : Action
{
    public SharedVector3 returnedPos;


    public override void OnStart()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            returnedPos.Value = hit.point;
        }
    }
}
