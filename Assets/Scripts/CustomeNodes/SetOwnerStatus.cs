using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.BehaviourTrees
{

	[Category("✫ Custom")]
	[Description("Set claim data on target object")]
	public class SetOwnerStatus<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<T> targetObject;
		[RequiredField]
		public BBParameter<bool> claim;
		[RequiredField]
		public BBParameter<AIActorData> actorData;

		protected override void OnExecute()
		{
			if (typeof(ResourceSource).IsAssignableFrom(typeof(T)))
			{
				ResourceSource resourceSource = targetObject.value as ResourceSource;
				if (resourceSource == null)
				{
					EndAction(false);
				}
				if (claim.value)
				{
					if (resourceSource.TryClaim(actorData.value))
					{
						EndAction(true);
					}
					EndAction(false);
				}
				else
				{
					resourceSource.UnClaim(actorData.value);
				}
				EndAction(true);
			}

			if (typeof(BuildingSpot).IsAssignableFrom(typeof(T)))
			{
				BuildingSpot buildingSpot = targetObject.value as BuildingSpot;
				if(buildingSpot == null)
                {
					EndAction(false);
				}
                if (claim.value)
                {
                    if (buildingSpot.TryClaim(actorData.value))
                    {
						EndAction(true);
					}
					EndAction(false);
				}
                else
                {
					buildingSpot.UnClaim(actorData.value);
                }
				EndAction(true);
			}

		}
	}
}