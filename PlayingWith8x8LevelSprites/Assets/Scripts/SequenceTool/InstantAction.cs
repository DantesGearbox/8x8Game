using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class InstantAction : Action
	{
		//SetToValue

		// --- Functions that might be overriden by subclasses ---
		
		public override void StartAction()
		{
			isExecuting = true;
		}

		public override void EndAction()
		{
			isExecuting = false;
			hasExecuted = true;
		}
	}
}
