using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{

    [Category("✫ Custom")]
    public class CheckHoldingResource<T> : ConditionTask
    {

        [BlackboardOnly]
        public BBParameter<T> HoldingResource;

        protected override string info
        {
            get { return "Check if We are holding a Resource"; }
        }

        protected override bool OnCheck()
        {
            if (!typeof(ResourceObject).IsAssignableFrom(typeof(T)))
            {
                return false;
            }
            if (HoldingResource.value == null)
            {
                return false;
            }

            return true;
        }
    }
}