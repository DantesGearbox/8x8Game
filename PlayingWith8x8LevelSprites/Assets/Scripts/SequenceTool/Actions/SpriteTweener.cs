using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Actually just changes the sprite immediately, doesn't do anything.
//Doesn't enforce that the chosen sprite is always selected, other code can change that.

public class SpriteTweener : SequenceAction
{
	public SpriteRenderer spriteRendererReference;
	public Sprite spriteToChangeTo;

	public override void StartTween()
	{
		spriteRendererReference.sprite = spriteToChangeTo;
	}

	public override void StopTween()
	{

	}
}
