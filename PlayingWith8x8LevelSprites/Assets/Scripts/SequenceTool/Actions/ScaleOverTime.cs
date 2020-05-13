using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class ScaleOverTime : OverTimeAction
	{
		public Transform transformReference;

		public Vector3 startValue;
		public Vector3 endValue;

		private Vector3 onEnterValue;

		protected override void RestoreOriginalValue()
		{
			transformReference.localScale = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			transformReference.localScale = endValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = transformReference.localScale;
		}

		protected override void UpdateValue()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			transformReference.localScale = Vector3.Lerp(startValue, endValue, normalizedTimer);
		}
	}
}