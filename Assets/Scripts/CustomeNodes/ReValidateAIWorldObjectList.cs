using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.BehaviourTrees
{

	[Category("✫ Custom/Blackboard/Lists")]
	[Description("Removes all Objects that are claimed from the list and stores it in a seperate list")]
	public class ReValidateAIWorldObjectList<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<T>> targetList;
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<T>> storeList;

		protected override void OnExecute()
		{
			if (typeof(ResourceObject).IsAssignableFrom(typeof(T)))
			{
				List<T> ToRemove = new();
				List<T> newList = targetList.value;

				foreach (T obj in targetList.value)
				{
					if (obj == null) { continue; }
					ResourceObject resourceObject = obj as ResourceObject;

					if (resourceObject.PickedUp)
					{
						ToRemove.Add(obj);
					}
				}
				foreach (T obj in ToRemove)
				{
					newList.Remove(obj);
				}
				storeList.value = newList;

				EndAction(true);
			}

            if (typeof(BuildingSpot).IsAssignableFrom(typeof(T)))
            {
				List<T> ToRemove = new();
				List<T> newList = targetList.value;

				foreach (T obj in targetList.value)
				{
					if (obj == null) { continue; }
					BuildingSpot buildingSpotObject = obj as BuildingSpot;

					if (buildingSpotObject.IsClaimed())
					{
						ToRemove.Add(obj);
					}
				}
				foreach (T obj in ToRemove)
				{
					newList.Remove(obj);
				}
				storeList.value = newList;

				EndAction(true);
			}
			if (typeof(ResourceSource).IsAssignableFrom(typeof(T)))
			{
				List<T> ToRemove = new();
				List<T> newList = targetList.value;

				foreach (T obj in targetList.value)
				{
					if (obj == null) { continue; }
					ResourceSource source = obj as ResourceSource;

					if (source.IsClaimed())
					{
						ToRemove.Add(obj);
					}
				}
				foreach (T obj in ToRemove)
				{
					newList.Remove(obj);
				}
				storeList.value = newList;

				EndAction(true);
			}

			if (typeof(House).IsAssignableFrom(typeof(T)))
			{
				List<T> ToRemove = new();
				List<T> newList = targetList.value;

				foreach (T obj in targetList.value)
				{
					if (obj == null) { continue; }
					House house = obj as House;

					if (house.GetActorsCount() > 2)
					{
						ToRemove.Add(obj);
					}
				}
				foreach (T obj in ToRemove)
				{
					newList.Remove(obj);
				}
				storeList.value = newList;

				EndAction(true);
			}
			EndAction(false);

		}
	}
}