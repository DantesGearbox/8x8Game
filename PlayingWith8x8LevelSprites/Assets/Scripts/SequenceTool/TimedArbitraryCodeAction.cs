using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class TimedArbitraryCodeAction : Action
	{
		public float actionDuration = 0;
		protected float actionTimer = 0;


		// --- Functions that might be overriden by subclasses ---

		protected virtual void Update()
		{
			if (!isExecuting) { return; }
			
			UpdateTimer();
		}

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
