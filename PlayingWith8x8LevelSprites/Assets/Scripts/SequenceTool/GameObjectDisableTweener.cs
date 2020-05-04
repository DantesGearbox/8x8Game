using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDisableTweener : SequenceAction
{
	public GameObject GameObjectReference;

	public override void StartTween()
	{
		GameObjectReference.SetActive(false);
	}

	public override void StopTween()
	{

	}
}
