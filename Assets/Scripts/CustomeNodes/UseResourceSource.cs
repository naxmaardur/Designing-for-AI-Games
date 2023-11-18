using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.BehaviourTrees
{

	[Category("✫ Custom")]
	[Description("Set claim data on target object")]
	public class UseResourceSource<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<T> targetObject;

		protected override void OnExecute()
		{
			if (typeof(ResourceSource).IsAssignableFrom(typeof(T)))
			{
				ResourceSource resourceSource = targetObject.value as ResourceSource;
				if (resourceSource == null)
				{
					targetObject.value = default(T);
					EndAction(false);
				}
				resourceSource.UseSource();
				EndAction(true);
			}
		}
	}
}