using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class OverFixedTimePingPongAction : OverFixedTimeAction
	{
		public float pingPongDuration = 0;
		protected float pingPongTimer = 0;

		// Used to store the startValue and endValue for later restoration
		protected abstract void StoreOnEnterValues();
		
		// Used to restore the startValue and endValue after they have been swapped around by the PingPong
		protected abstract void RestoreOnEnterValues();
		
		// Swap the start and end values so we can ping pong
		protected abstract void SwapStartAndEndValues();

		protected void EndPingPong()
		{
			SwapStartAndEndValues();
		}

		protected override void FixedUpdate()
		{
			base.FixedUpdate();

			if (!isExecuting) { return; }
			UpdatePingPongTimer();
		}

		public override void StartAction()
		{
			base.StartAction();
			StoreOnEnterValues();
		}

		public override void EndAction()
		{
			RestoreOnEnterValues();
			base.EndAction();
		}

		protected void UpdatePingPongTimer()
		{
			pingPongTimer += Time.deltaTime;

			if (pingPongTimer > pingPongDuration)
			{
				pingPongTimer = 0;
				EndPingPong();
			}
		}
	}
}