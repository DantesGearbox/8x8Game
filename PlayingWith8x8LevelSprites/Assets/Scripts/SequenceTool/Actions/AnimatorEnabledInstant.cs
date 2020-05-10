using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class AnimatorEnabledInstant : InstantAction
	{
		public Animator animator;
		public bool setTo = false;

		protected override void SetToValue()
		{
			animator.enabled = setTo;
		}
	}
}