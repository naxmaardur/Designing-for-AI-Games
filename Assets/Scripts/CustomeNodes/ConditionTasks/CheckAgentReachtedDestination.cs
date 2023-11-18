
using System.Collections.Generic;
using System.Linq;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

#if UNITY_5_5_OR_NEWER
using NavMeshAgent = UnityEngine.AI.NavMeshAgent;
using NavMeshPathStatus = UnityEngine.AI.NavMeshPathStatus;
#endif

namespace NodeCanvas.Tasks.Conditions
{
    [Category("✫ Custom/Movement/Pathfinding")]
    [Description("Check if agent is pathing to a location")]
    public class CheckAgentReachtedDestination : ConditionTask<NavMeshAgent>
    {
        public BBParameter<float> keepDistance = 0.1f;
        protected override bool OnCheck()
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance + keepDistance.value)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }

            return false;
        }
    }
}