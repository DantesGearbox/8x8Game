using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTweener : Tween
{
	public Transform transformReference;

	public Vector3 startingValue;
	public Vector3 endValue;

	private bool isTweening = false;

	private void Update()
	{
		if (isTweening)
		{
			UpdateScale();
			UpdateTimer();
		}
	}

	private void UpdateScale()
	{
		float normalizedTimer = NormalizeTo01Scale(0, tweenDuration, tweenTimer);
		transformReference.localScale = Vector3.Lerp(startingValue, endValue, normalizedTimer);
	}

	private void UpdateTimer()
	{
		tweenTimer += Time.deltaTime;

		if (tweenTimer > tweenDuration)
		{
			StopTween();
			SetStartValueToEndValue(); //Make sure the current value gets to the max, even with slight lerp errors
		}
	}

	private void SetStartValueToEndValue()
	{
		transformReference.localScale = endValue;
	}

	public override void StartTween()
	{
		isTweening = true;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
	}
}
