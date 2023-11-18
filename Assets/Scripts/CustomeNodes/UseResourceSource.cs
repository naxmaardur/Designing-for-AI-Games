using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.BehaviourTrees
{

	[Category("✫ Custom")]
	[Description("Trigger Use on resource or source")]
	public class UseResourceSource<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<T> targetObject;
		[BlackboardOnly]
		public BBParameter<AIActorData> actorData;

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
			if (typeof(ResourceObject).IsAssignableFrom(typeof(T)))
			{
				ResourceObject resource = targetObject.value as ResourceObject;
				if (resource == null)
				{
					targetObject.value = default(T);
					EndAction(false);
				}
				if (actorData.value != null)
				{
					resource.Use(actorData.value);
				}
				else
				{
					resource.Use();
				}
				EndAction(true);
			}
		}
	}
}