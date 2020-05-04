using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
	public SequenceAction[] tweens;

	private float timer = 0;
	private bool timerIsRunning = false;

	private void Start()
	{
		tweens = GetComponentsInChildren<SequenceAction>();
	}

	private void Update()
	{
		if (timerIsRunning)
		{
			timer += Time.deltaTime;
		}

		foreach (SequenceAction tween in tweens)
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
		foreach(SequenceAction tween in tweens)
		{
			tween.hasTweened = false;
		}
	}
}
