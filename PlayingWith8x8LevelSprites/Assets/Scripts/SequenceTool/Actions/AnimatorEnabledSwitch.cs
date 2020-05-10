using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class AnimatorEnabledSwitch : SwitchAction
	{
		public Animator animator;

		public bool startValue;
		public bool endValue;

		private bool onEnterValue;
		
		protected override void RestoreOriginalValue()
		{
			animator.enabled = onEnterValue;
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
	}
}