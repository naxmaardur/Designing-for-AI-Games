using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

using NavMeshAgent = UnityEngine.AI.NavMeshAgent;

namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom/Movement/Pathfinding")]
    public class SeekRandomPointInSphere : ActionTask<NavMeshAgent>
    {

        public BBParameter<Vector3> targetPosition;
        public BBParameter<float> speed = 4;
        public BBParameter<float> keepDistance = 0.1f;
        public BBParameter<float> sphereSize = 15f;
        private Vector3 targetpoint;

        private Vector3? lastRequest;

        protected override string info
        {
            get { return "Seek " + targetPosition; }
        }

        protected override void OnExecute()
        {
            agent.speed = speed.value;
            targetpoint = Random.insideUnitCircle * sphereSize.value;
            targetpoint.z = targetpoint.y;
            targetpoint.y = 0;
            targetpoint = targetPosition.value + targetpoint;

            if (Vector3.Distance(agent.transform.position, targetpoint) < agent.stoppingDistance + keepDistance.value)
            {
                EndAction(true);
                return;
            }
        }

        protected override void OnUpdate()
        {
            if (lastRequest != targetpoint)
            {
                if (!agent.SetDestination(targetpoint))
                {
                    EndAction(false);
                    return;
                }
            }

            lastRequest = targetpoint;

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + keepDistance.value)
            {
                EndAction(true);
            }
        }

        protected override void OnPause() { OnStop(); }
        protected override void OnStop()
        {
            if (lastRequest != null && agent.gameObject.activeSelf)
            {
                agent.ResetPath();
            }
            lastRequest = null;
        }
    }
}