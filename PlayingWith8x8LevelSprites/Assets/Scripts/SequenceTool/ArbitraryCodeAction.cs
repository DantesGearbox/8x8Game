using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class ArbitraryCodeAction : Action
	{
		// Executes whatever you want
		protected abstract void ArbitraryCode();

		public override void StartAction()
		{
			isExecuting = true;
			ArbitraryCode();
			EndAction();
		}

		public override void EndAction()
		{
			isExecuting = false;
			hasExecuted = true;
		}
	}
}
