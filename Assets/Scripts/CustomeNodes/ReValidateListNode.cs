using System.Collections;
using System.Linq;
using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{

	[Category("✫ Custom/Blackboard/Lists")]
	[Description("Removes all picked up Resources from the list")]
	public class ReValidateListNode<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<T>> targetList;

		protected override void OnExecute()
		{
			//targetList.value =   targetList.value.Where(x => x != null).ToList();
			//Why is Where not allowed.....

			List<int> list = new();
			for(int i = 0; i < targetList.value.Count; i++)
            {
				if (typeof(MonoBehaviour).IsAssignableFrom(typeof(T)))
				{
					MonoBehaviour obj = targetList.value[i] as MonoBehaviour;
					if (obj == null)
					{
						list.Add(i);
					}
				}
				else
				{
					T obj = targetList.value[i];
					if (obj == null)
					{
						list.Add(i);
					}
				}
            }
			for(int i = list.Count -1; i > -1; i--)
            {
				targetList.value.RemoveAt(list[i]);
            }
			EndAction(true);
		}
	}
}