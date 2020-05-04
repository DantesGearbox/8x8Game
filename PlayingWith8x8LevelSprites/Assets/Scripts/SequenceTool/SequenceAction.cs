using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SequenceAction : MonoBehaviour
{
	[HideInInspector] public bool hasTweened = false;

	public float startingTime = 0;
	public float tweenDuration = 0;
	protected float tweenTimer = 0;

	public abstract void StartTween();
	public abstract void StopTween();



	//--- Used by sub-classes ---
	protected float NormalizeTo01Scale(float startVal, float maxVal, float currVal)
	{
		float nonOffsetValue = currVal - startVal;
		float nonOffsetMaxValue = maxVal - startVal;

		float normalizedValue = nonOffsetValue / nonOffsetMaxValue;

		return normalizedValue;
	}
}
