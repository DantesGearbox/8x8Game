using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class SwitchAction : Action
	{
		//StartValue
		//EndValue
		//Duration
		//Timer
		//UpdateTimer function
		//Loop (But probably in seperate classes for now)

		public bool restoreAfterExecution = false;
		public float actionDuration = 0;
		protected float actionTimer = 0;

		/// <summary>
		/// Function is called if users check "restoreAfterExecution", implement accordingly
		/// </summary>
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
