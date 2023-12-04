using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.BehaviourTrees
{

    [Category("✫ Custom")]
    [Description("Set claim data on target object")]
    public class SetActorInsideHouse : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<House> targetObject;
        [RequiredField]
        public BBParameter<bool> claim;
        [RequiredField]
        public BBParameter<AIActorData> actorData;

        protected override void OnExecute()
        {
            House house = targetObject.value;
            if (house == null)
            {
                EndAction(false);
            }
            if (claim.value)
            {
                house.AddInsideActor(actorData.value);
            }
            else
            {
                house.RemoveInsideActor(actorData.value);
            }
            EndAction(true);
        }
    }
}