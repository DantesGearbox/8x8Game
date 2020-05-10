using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class AnimatorEnabledSwitchPingPong : SwitchPingPongAction
	{
		public Animator animator;

		public bool startValue;
		public bool endValue;

		private bool onEnterStartValue;
		private bool onEnterEndValue;
		private bool onEnterValue;

		protected override void RestoreOnEnterValues()
		{
			startValue = onEnterStartValue;
			endValue = onEnterEndValue;
		}

		protected override void RestoreOriginalValue()
		{
			animator.enabled = onEnterValue;
		}

		protected override void SaveOnEnterValues()
		{
			onEnterStartValue = startValue;
			onEnterEndValue = endValue;
		}

		protected override void SetToEndValue()
		{
			animator.enabled = endValue;
		}

		protected override void SetToStartValue()
		{
			animator.enabled = startValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = animator.enabled;
		}

		protected override void SwapStartAndEndValues()
		{
			bool temp = endValue;
			endValue = startValue;
			startValue = temp;
		}
	}
}