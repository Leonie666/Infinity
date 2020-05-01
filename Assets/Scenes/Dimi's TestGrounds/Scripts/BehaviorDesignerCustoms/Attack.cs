using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Custom")]
//[TaskIcon("Assets/Behavior Designer/Runtime/Tasks/Custom/PointPatrolIconN.png")]
[TaskDescription("Aims at the Target with rotational speed of aimSpeed for aimTime seconds, and shoots afterwards at 2x attackDistance far a raycast which hits all whatLayersDoIHit layers causing a random [0 to damage] damage on all gameobjects with the layers hit by the ray")]
public class Attack : Action
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("Seconds Aiming before shooting")]
    public SharedFloat aimTime;
    public SharedFloat aimSpeed;
    public SharedFloat attackDistance;

    public SharedGameObject targetGameObject;

    public SharedLayerMask whatLayersDoIHit;

    public SharedInt damage;

    private Ray ray;
    private RaycastHit hit;
    private float currAimTime = 0;
    private int damageCaused;

    public override TaskStatus OnUpdate()
    {
        if (AimOnTarget())
        {
            currAimTime = 0;

            if (Physics.Raycast(ray, out hit, attackDistance.Value * 2f, whatLayersDoIHit.Value))
            {
                //Play shoot animation
                damageCaused = Random.Range(0, damage.Value);
                hit.transform.GetComponent<PlayerMovement>().TakeDamage(damageCaused);
                
                return TaskStatus.Success;
            }
        }

        

        return TaskStatus.Failure;
    }


    private bool AimOnTarget()
    {
        if (currAimTime >= aimTime.Value) return true;
        if (currAimTime < aimTime.Value)
        {
            currAimTime += Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(
                transform.position,
                targetGameObject.Value.transform.position - transform.position,
                aimSpeed.Value * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        ray = new Ray(GetDefaultGameObject(gameObject).transform.position, targetGameObject.Value.transform.position);
        return false;
    }
}
