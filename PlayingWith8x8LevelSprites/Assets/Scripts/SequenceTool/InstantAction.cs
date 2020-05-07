using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class InstantAction : Action
	{
		// Sets the current value to setToValue
		protected abstract void SetToValue();

		// --- Functions that might be overriden by subclasses ---

		public override void StartAction()
		{
			isExecuting = true;
			SetToValue();
		}

		public override void EndAction()
		{
			isExecuting = false;
			hasExecuted = true;
		}
	}
}
