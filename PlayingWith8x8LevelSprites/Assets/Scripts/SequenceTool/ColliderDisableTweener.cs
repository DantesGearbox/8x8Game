using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisableTweener : SequenceAction
{
	public Collider2D ColliderReference;

	private bool isTweening = false;

	private void Update()
	{
		if (isTweening)
		{
			tweenTimer += Time.deltaTime;
			if(tweenTimer > tweenDuration)
			{
				ColliderReference.enabled = true;
				StopTween();
			}
		}
	}

	public override void StartTween()
	{
		isTweening = true;
		ColliderReference.enabled = false;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
	}
}
