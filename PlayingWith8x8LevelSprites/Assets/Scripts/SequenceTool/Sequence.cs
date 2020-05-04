using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class Sequence : MonoBehaviour
	{
		public Action[] tweens;

		private float timer = 0;
		private bool timerIsRunning = false;

		private void Start()
		{
			tweens = GetComponentsInChildren<Action>();
		}

		private void Update()
		{
			if (timerIsRunning)
			{
				timer += Time.deltaTime;
			}

			foreach (Action tween in tweens)
			{
				if (timer > tween.startingTime && !tween.hasExecuted)
				{
					tween.hasExecuted = true;
					tween.StartAction();
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
			foreach (Action tween in tweens)
			{
				tween.hasExecuted = false;
			}
		}
	}
}
