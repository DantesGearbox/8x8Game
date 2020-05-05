using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class OverTimeAction : Action
	{
		//StartValue
		//EndValue
		//Tween type
		//Duration
		//Timer
		//UpdateTimer function
		//Return to start value after execution variable
		//Return to start value after execution function
		//Loop + Pingpong (But probably in seperate classes for now)


		public float actionDuration = 0;
		public bool restoreStartValueAfterExecution = false;

		protected float actionTimer = 0;

		protected void UpdateTimer()
		{
			actionTimer += Time.deltaTime;

			if (actionTimer > actionDuration)
			{
				StopAction();
			}
		}

		protected abstract void RestoreStartValueAfterExecution();
	}
}
