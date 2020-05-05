using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class SwitchAction : Action
	{
		//StartValue
		//EndValue
		//Duration
		//Timer
		//UpdateTimer function
		//Loop (But probably in seperate classes for now)


		public float actionDuration = 0;
		protected float actionTimer = 0;

		protected void UpdateTimer()
		{
			actionTimer += Time.deltaTime;

			if (actionTimer > actionDuration)
			{
				StopAction();
				SetToEndValue();
			}
		}

		protected abstract void SetToEndValue();
	}
}
