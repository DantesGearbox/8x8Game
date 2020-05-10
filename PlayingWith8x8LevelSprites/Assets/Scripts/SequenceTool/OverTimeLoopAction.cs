using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class OverTimeLoopAction : OverTimeAction
	{
		public float loopDuration = 0;
		protected float loopTimer = 0;

		protected override void Update()
		{
			base.Update();

			if (!isExecuting) { return; }
			UpdateLoopTimer();
		}

		protected void EndLoop()
		{
			SetToEndValue();
		}

		protected void UpdateLoopTimer()
		{
			loopTimer += Time.deltaTime;

			if (loopTimer > loopDuration)
			{
				loopTimer = 0;
				EndLoop();
			}
		}
	}
}
