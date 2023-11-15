using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom/Blackboard/Lists")]
    [Description("Get the closer object to the agent from within a list of objects and save it in the blackboard. (The Object has to be a MonoBehaviour)")]
    public class GetCloserObjectInList<T> : ActionTask<Transform>
    {

        [RequiredField]
        public BBParameter<List<T>> list;

        [BlackboardOnly]
        public BBParameter<T> saveAs;

        protected override string info
        {
            get { return "Get Closer from '" + list + "' as " + saveAs; }
        }

        protected override void OnExecute()
        {

            if (list.value.Count == 0)
            {
                EndAction(false);
                return;
            }
            if (!typeof(MonoBehaviour).IsAssignableFrom(typeof(T)))
            {
                EndAction(false);
            }

            var closerDistance = Mathf.Infinity;
            T closerGO = default(T);
            for(int i = 0; i < list.value.Count; i++)
            {
                MonoBehaviour gameObject = list.value[i] as MonoBehaviour;
                if(gameObject == null) {
                    //list.value[i] = default(T);
                    continue; 
                }
                var dist = Vector3.Distance(agent.position, gameObject.transform.position);
                if (dist < closerDistance)
                {
                    closerDistance = dist;
                    closerGO = list.value[i];
                }
            }
            if(closerGO == null)
            {
                EndAction(false);
            }

            saveAs.value = closerGO;
            EndAction(true);
        }
    }
}