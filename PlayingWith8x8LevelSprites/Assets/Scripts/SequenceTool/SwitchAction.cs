using UnityEngine;

namespace SequenceTool
{
	public abstract class SwitchAction : Action
	{
		public float actionDuration = 0;
		protected float actionTimer = 0;

		[Tooltip("After execution, return to the state when the action started, instead of EndValue.")]
		public bool restoreOriginalValue = false;

		// Function is called if users check "useRestoreValue", use at the end of action to restore the OnEnterValue
		protected abstract void RestoreOriginalValue();

		// Used to store the onEnterValue for later restoration
		protected abstract void StoreOriginalValue();

		// Sets the current value to startValue
		protected abstract void SetToStartValue();

		// Sets the current value to endValue
		protected abstract void SetToEndValue();


		// --- Functions that might be overriden by subclasses ---

		protected virtual void Update()
		{
			if (!isExecuting) { return; }
			SetToStartValue();
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

			SetToStartValue();
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
