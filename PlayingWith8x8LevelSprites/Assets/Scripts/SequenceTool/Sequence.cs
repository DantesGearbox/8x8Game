using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class Sequence : MonoBehaviour
	{
		public Action[] actions;

		private float timer = 0;
		private bool timerIsRunning = false;

		private void Start()
		{
			actions = GetComponentsInChildren<Action>();
		}

		private void Update()
		{
			if (timerIsRunning)
			{
				timer += Time.deltaTime;
			}

			foreach (Action action in actions)
			{
				if (timer > action.startingTime && !action.hasExecuted)
				{
					action.hasExecuted = true;
					action.StartAction();
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
			ResetActions();

		}

		public void PauseTimer()
		{
			timerIsRunning = false;
		}

		private void ResetActions()
		{
			foreach (Action action in actions)
			{
				action.hasExecuted = false;
			}
		}
	}
}
