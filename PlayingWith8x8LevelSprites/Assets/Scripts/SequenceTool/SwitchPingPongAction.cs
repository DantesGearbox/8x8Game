using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class SwitchPingPongAction : SwitchAction
	{
		public float pingPongDuration = 0;
		protected float pingPongTimer = 0;

		// Swap the start and end values so we can ping pong
		protected abstract void SwapStartAndEndValues();

		// Used to store the onEnterValue, startValue and endValue for later restoration
		protected abstract void SaveOnEnterValues();

		// Used to restore the startValue and endValue after they have been swapped around by the PingPong
		protected abstract void RestoreOnEnterValues();

		protected void EndPingPong()
		{
			SwapStartAndEndValues();
			SetToEndValue();
		}

		protected override void Update()
		{
			base.Update();

			if (!isExecuting) { return; }
			UpdatePingPongTimer();
		}

		public override void StartAction()
		{
			base.StartAction();
			SaveOnEnterValues();
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
