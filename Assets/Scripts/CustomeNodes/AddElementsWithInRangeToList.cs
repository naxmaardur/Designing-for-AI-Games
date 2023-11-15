using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    [Category("✫ Custom/Blackboard/Lists")]
    public class AddElementsWithInRangeToList<T> : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<List<T>> targetList;
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<float> targetRange;
        [RequiredField]
        [BlackboardOnly]
        public BBParameter<LayerMask> layerMask;

        protected override string info
        {
            get { return string.Format("Add all Elements in a range of {0} Into {1}",targetRange, targetList); }
        }

        protected override void OnExecute()
        {
            Vector3 position = agent.transform.position;
            Collider[] colliders = Physics.OverlapSphere(position, targetRange.value, layerMask.value);

            foreach(Collider col in colliders)
            {
                T component = col.gameObject.GetComponent<T>();
                if(component != null)
                {
                    if (!targetList.value.Contains(component))
                    {
                        targetList.value.Add(component);
                    }
                }
            }
            EndAction();
        }
    }
}
