using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyTweener : Tween
{
	public GameObject GameObjectReference;

	public override void StartTween()
	{
		Destroy(GameObjectReference);
	}

	public override void StopTween()
	{

	}
}
