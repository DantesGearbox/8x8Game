using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDisableTweener : Tween
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
