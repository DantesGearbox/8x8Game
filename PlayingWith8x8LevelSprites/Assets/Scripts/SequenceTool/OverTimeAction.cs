using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class OverTimeAction : Action
	{
		//Start value
		//End value
		//Tween type
		//Duration
		//Timer
		//UpdateTimer function
		//Return to start value after execution variable
		//Return to start value after execution function
		//Loop + Pingpong (But probably in seperate classes for now)

		public bool restoreAfterExecution = false;
		public float actionDuration = 0;
		protected float actionTimer = 0;
		protected abstract void RestoreStartValueAfterExecution();


		// --- Functions that might be overriden by subclasses ---

		protected void UpdateTimer()
		{
			actionTimer += Time.deltaTime;

			if (actionTimer > actionDuration)
			{
				EndAction();
			}
		}

		public override void StartAction()
		{
			isExecuting = true;
			actionTimer = 0;
		}

		public override void EndAction()
		{
			isExecuting = false;
			hasExecuted = true;
		}
	}
}
