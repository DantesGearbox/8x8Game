using UnityEngine;

namespace SequenceTool
{
	public class FloatOverTime : OverTimeAction
	{
		public FloatWrapper referencedFloat;

		public float startValue;
		public float endValue;

		private float onEnterValue;

		protected override void RestoreOriginalValue()
		{
			referencedFloat.floatValue = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			referencedFloat.floatValue = endValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = referencedFloat.floatValue;
		}

		protected override void UpdateValue()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			referencedFloat.floatValue = Mathf.Lerp(startValue, endValue, normalizedTimer);
		}
	}
}