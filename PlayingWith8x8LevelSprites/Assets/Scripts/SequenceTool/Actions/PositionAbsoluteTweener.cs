using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{

}

public class PositionAbsoluteTweener
{
	//public Transform transformReference;

	//public Vector3 startingValue;
	//public Vector3 endValue;

	//private bool isTweening = false;

	//private void Update()
	//{
	//	if (isTweening)
	//	{
	//		UpdatePosition();
	//		UpdateTimer();
	//	}
	//}

	//private void UpdatePosition()
	//{
	//	float normalizedTimer = NormalizeTo01Scale(0, tweenDuration, tweenTimer);
	//	transformReference.localPosition = Vector3.Lerp(startingValue, endValue, normalizedTimer);
	//}

	//private void UpdateTimer()
	//{
	//	tweenTimer += Time.deltaTime;

	//	if (tweenTimer > tweenDuration)
	//	{
	//		StopTween();
	//		SetStartValueToEndValue(); //Make sure the current value gets to the max, even with slight lerp errors
	//	}
	//}

	//private void SetStartValueToEndValue()
	//{
	//	transformReference.localPosition = endValue;
	//}

	//public override void StartTween()
	//{
	//	isTweening = true;
	//}

	//public override void StopTween()
	//{
	//	isTweening = false;
	//	tweenTimer = 0;
	//}
}
