using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.BehaviourTrees
{

	[Category("✫ Custom/Blackboard/Lists")]
	[Description("Removes all picked up Resources from the list")]
	public class ReValidateResourceListNode<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<T>> targetList;

		protected override void OnExecute()
		{
			if (!typeof(ResourceObject).IsAssignableFrom(typeof(T)))
			{
				EndAction(false);
			}
			else
			{
				List<T> ToRemove = new();

				foreach (T obj in targetList.value)
				{
					if(obj == null) { continue; }
					ResourceObject resourceObject = obj as ResourceObject;

					if (resourceObject.PickedUp)
					{
						ToRemove.Add(obj);
					}
				}
				foreach (T obj in ToRemove)
				{
					targetList.value.Remove(obj);
				}

				EndAction(true);
			}
		}
	}
}