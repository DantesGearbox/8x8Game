using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Activatable
{
	public float activationTime = 0;
	public float duration = 0;
	public Tween tween;
	public bool hasTweened = false;

	public void Activate()
	{
		tween.StartTween();
		hasTweened = true;
	}

	//public bool IsTweening()
	//{
	//	return tween.isTweening;
	//}
}
