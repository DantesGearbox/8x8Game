using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Remember to replace the comments below with code that works for the tweeeeeeeens

public class Sequence : MonoBehaviour
{
	public Tween[] tweens;

	private float timer = 0;
	private bool timerIsRunning = false;

	private void Start()
	{
		tweens = GetComponentsInChildren<Tween>();
	}

	private void Update()
	{
		if (timerIsRunning)
		{
			timer += Time.deltaTime;
		}

		foreach (Tween tween in tweens)
		{
			if (timer > tween.startingTime && !tween.hasTweened)
			{
				tween.hasTweened = true;
				tween.StartTween();
			}
		}
	}

	public bool IsTimerRunning()
	{
		return timerIsRunning;
	}

	public void StartTimer()
	{
		timerIsRunning = true;
	}

	public void StopTimer()
	{
		timerIsRunning = false;
		timer = 0;
		ResetTweens();

	}

	public void PauseTimer()
	{
		timerIsRunning = false;
	}

	private void ResetTweens()
	{
		foreach(Tween tween in tweens)
		{
			tween.hasTweened = false;
		}
	}
}
