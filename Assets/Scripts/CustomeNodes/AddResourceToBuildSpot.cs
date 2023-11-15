using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom")]
    [Description("Trigger Resource Update on the buildspot Object")]
    public class AddResourceToBuildSpot : ActionTask<Transform>
    {

        [RequiredField]
        public BBParameter<BuildingSpot> buildSpotObject;

        [BlackboardOnly]
        public BBParameter<Wood> woodObject;
        

        protected override string info
        {
            get { return "Adds the wood object to the buildSpot Object"; }
        }

        protected override void OnExecute()
        {
            if(woodObject.value == null || buildSpotObject.value == null)
            {
                EndAction(false);
            }

            buildSpotObject.value.AddResource(woodObject.value);
            woodObject.value = null;

            EndAction(true);
        }
    }
}