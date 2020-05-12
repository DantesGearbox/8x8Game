using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class BoolSwitch : SwitchAction
	{
		[Header(" ")]
		public BoolWrapper boolRef;

		public bool startValue;
		public bool endValue;

		private bool onEnterValue;

		protected override void RestoreOriginalValue()
		{
			boolRef.boolValue = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			boolRef.boolValue = endValue;
		}

		protected override void SetToStartValue()
		{
			boolRef.boolValue = startValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = boolRef.boolValue;
		}
	}
}

public class BoolTweener
{
	//public BoolWrapper refencedBool;
	//public bool setReferencedBoolTo = false;

	//private bool isTweening = false;

	//private void Update()
	//{
	//	if (isTweening)
	//	{
	//		tweenTimer += Time.deltaTime;
	//		if(tweenTimer > tweenDuration)
	//		{
	//			refencedBool.boolValue = !setReferencedBoolTo;
	//			StopTween();
	//		}
	//	}
	//}

	//public override void StartTween()
	//{
	//	isTweening = true;
	//	refencedBool.boolValue = setReferencedBoolTo;
	//}

	//public override void StopTween()
	//{
	//	isTweening = false;
	//	tweenTimer = 0;
	//}
}
