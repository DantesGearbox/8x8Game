using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class BehaviorEnabledSwitch : SwitchAction
	{
		public Behaviour behaviourRef;

		public bool startValue;
		public bool endValue;

		private bool onEnterValue;

		protected override void RestoreOriginalValue()
		{
			behaviourRef.enabled = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			behaviourRef.enabled = endValue;
		}

		protected override void SetToStartValue()
		{
			behaviourRef.enabled = startValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = behaviourRef.enabled;
		}
	}
}
