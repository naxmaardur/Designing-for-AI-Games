using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom")]
    [Description("Trigger Drop on the resource and save it in the blackboard. (The Object has to be a ResourceObject)")]
    public class DropResource<T> : ActionTask<Transform>
    {

        [RequiredField]
        [BlackboardOnly]
        public BBParameter<T> objectDrop;

       

        protected override string info
        {
            get { return "drop Resource '" + objectDrop + "' and clear referance"; }
        }

        protected override void OnExecute()
        {

            if (!typeof(ResourceObject).IsAssignableFrom(typeof(T)))
            {
                EndAction(false);
            }
            
            ResourceObject resourceObject = objectDrop.value as ResourceObject;
            resourceObject.Drop();
            objectDrop.value = default(T);

            EndAction(true);
        }
    }
}