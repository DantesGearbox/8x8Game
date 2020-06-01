using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class OverFixedTimeLoopAction : OverFixedTimeAction
	{
		public float loopDuration = 0;
		protected float loopTimer = 0;

		protected override void FixedUpdate()
		{
			base.FixedUpdate();

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
