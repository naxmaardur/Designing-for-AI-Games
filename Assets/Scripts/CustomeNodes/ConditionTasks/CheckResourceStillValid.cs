using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{

    [Category("✫ Custom")]
    public class CheckResourceStillValid<T> : ConditionTask
    {

        [BlackboardOnly]
        public BBParameter<T> TargetResource;
        [BlackboardOnly]
        public BBParameter<T> HoldingResource;

        protected override string info
        {
            get { return "Target is not picked up when not holding a object"; }
        }

        protected override bool OnCheck()
        {
            if (!typeof(ResourceObject).IsAssignableFrom(typeof(T)))
            {
                return false;
            }
            if(TargetResource.value == null)
            {
                return false;
            }

            ResourceObject target = TargetResource.value as ResourceObject;

            if(target.PickedUp && HoldingResource.value == null)
            {
                return false;
            }

            return true;
        }
    }
}