using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class Vector2OverTime : OverTimeAction
	{
		public Vector3Wrapper vectorReference;
		public Vector2 startValue;
		public Vector2 endValue;

		private Vector3 onEnterValue;

		protected override void RestoreOriginalValue()
		{
			vectorReference.vectorValue = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			vectorReference.vectorValue = endValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = vectorReference.vectorValue;
		}

		protected override void UpdateValue()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			vectorReference.vectorValue = Vector3.Lerp(startValue, endValue, normalizedTimer);
		}
	}
}