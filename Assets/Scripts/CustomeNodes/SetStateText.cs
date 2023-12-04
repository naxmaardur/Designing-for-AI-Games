using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;

namespace NodeCanvas.BehaviourTrees
{

	[Category("✫ Custom")]
	[Description("Sets the text on a TMP object to the string")]
	public class SetStateText: ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<TextMeshProUGUI> targetObject;
		public BBParameter<string> stringText;

		protected override void OnExecute()
		{
			targetObject.value.text = stringText.value;
			EndAction(true);
		}
	}
}