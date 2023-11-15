using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom")]
    [Description("Trigger Pickup on the resource and save it in the blackboard. (The Object has to be a ResourceObject)")]
    public class PickUpResource<T> : ActionTask<Transform>
    {

        [RequiredField]
        public BBParameter<T> objectToPickUp;

        [BlackboardOnly]
        public BBParameter<T> saveAs;
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<Transform> transform;

        protected override string info
        {
            get { return "Pick up Resource '" + objectToPickUp + "' as " + saveAs; }
        }

        protected override void OnExecute()
        {

            if (!typeof(ResourceObject).IsAssignableFrom(typeof(T)))
            {
                EndAction(false);
            }
            saveAs.value = objectToPickUp.value;
            ResourceObject resourceObject = objectToPickUp.value as ResourceObject;
            resourceObject.PickUp(transform.value);
           
            EndAction(true);
        }
    }
}