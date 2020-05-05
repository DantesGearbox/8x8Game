using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class OverTimePingPongAction : OverTimeAction
	{
		public float pingPongDuration = 0;
		protected float pingPongTimer = 0;

		protected abstract void EndPingPong();

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