using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class InstantAction : Action
	{
		//SetToValue

		public bool restoreStartValueAfterExecution = false;
		protected abstract void RestoreStartValueAfterExecution();
	}
}
