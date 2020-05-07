using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class OverTimeAction : Action
	{
		[Tooltip("After execution, return to the state when the action started, instead of EndValue.")]
		public bool restoreOriginalValue = false;
		public float actionDuration = 0;
		protected float actionTimer = 0;

		// Function is called if users check "restoreOriginalValue", implement accordingly
		protected abstract void RestoreOriginalValue();
		
		// Used to store the onEnterValue for later restoration
		protected abstract void StoreOriginalValue();

		// Sets the current value to endValue
		protected abstract void SetToEndValue();

		// Update the current value over time
		protected abstract void UpdateValue();


		// --- Functions that might be overriden by subclasses ---

		protected virtual void Update()
		{
			if (!isExecuting) { return; }

			UpdateValue();
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

			if (restoreOriginalValue)
			{
				StoreOriginalValue();
			}
		}

		public override void EndAction()
		{
			isExecuting = false;
			hasExecuted = true;

			if (restoreOriginalValue)
			{
				RestoreOriginalValue();
			}
			else
			{
				SetToEndValue();
			}
		}
	}
}
