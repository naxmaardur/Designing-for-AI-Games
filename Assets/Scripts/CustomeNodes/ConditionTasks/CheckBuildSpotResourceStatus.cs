using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{

    [Category("✫ Custom")]
    public class CheckBuildSpotResourceStatus : ConditionTask
    {

        [BlackboardOnly]
        public BBParameter<BuildingSpot> TargetBuildSpot;

        protected override string info
        {
            get { return "Checks if buildspot has enough Resources"; }
        }

        protected override bool OnCheck()
        {
            if (TargetBuildSpot.value == null)
            {
                TargetBuildSpot.value = null;
                return false;
            }


            

            return TargetBuildSpot.value.HasEnoughResources;
        }
    }
}