﻿
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using NavMeshAgent = UnityEngine.AI.NavMeshAgent;

namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom/Movement/Pathfinding")]
    public class SeekRandomPointAroundGameObject : ActionTask<NavMeshAgent>
    {

        [RequiredField]
        public BBParameter<GameObject> target;
        public BBParameter<float> speed = 4;
        public BBParameter<float> keepDistance = 0.1f;
        public BBParameter<float> sphereSize = 15f;
        private Vector3 targetpoint;


        private Vector3? lastRequest;

        protected override string info
        {
            get { return "Seek " + target; }
        }

        protected override void OnExecute()
        {
            if (target.value == null) { EndAction(false); return; }
            targetpoint = Random.insideUnitCircle * sphereSize.value;
            targetpoint.z = targetpoint.y;
            targetpoint.y = 0;
            targetpoint = target.value.transform.position + targetpoint;
            agent.speed = speed.value;
            if (Vector3.Distance(agent.transform.position, targetpoint) <= agent.stoppingDistance + keepDistance.value)
            {
                EndAction(true);
                return;
            }
        }

        protected override void OnUpdate()
        {
            if (target.value == null) { EndAction(false); return; }
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
            if (agent.gameObject.activeSelf)
            {
                agent.ResetPath();
            }
            lastRequest = null;
        }

        public override void OnDrawGizmosSelected()
        {
            if (targetpoint != null)
            {
                Gizmos.DrawWireSphere(targetpoint, keepDistance.value);
            }
        }
    }
}