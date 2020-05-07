using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class SwitchPingPongAction : SwitchAction
	{
		public float pingPongDuration = 0;
		protected float pingPongTimer = 0;

		/// <summary>
		/// What happens at the end of one ping
		/// </summary>
		protected abstract void EndPingPong();

		/// <summary>
		/// Used to store the startValue and endValue for later restoration
		/// </summary>
		protected abstract void SaveOnEnterValues();

		/// <summary>
		/// Used to restore the startValue and endValue after they have been swapped around by the PingPong
		/// </summary>
		protected abstract void RestoreOnEnterValues();

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
