using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom")]
    [Description("Trigger Build Update on the buildspot Object")]
    public class UpdateBuildingProgress : ActionTask<Transform>
    {

        [RequiredField]
        public BBParameter<BuildingSpot> buildSpotObject;


        protected override string info
        {
            get { return "Progresses the building progress on the Buildspot Object"; }
        }

        protected override void OnExecute()
        {
            if (buildSpotObject.value == null)
            {
                EndAction(false);
            }

            buildSpotObject.value.BuildUpdate();

            EndAction(true);
        }
    }
}