using UnityEngine;

namespace SequenceTool
{
	public class TintOverTime : OverTimeAction
	{
		public SpriteRenderer spriteRendererRef;
		public Color startTint;
		public Color endTint;
		private Color originalTint;

		protected override void UpdateValue()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			spriteRendererRef.color = Color.Lerp(startTint, endTint, normalizedTimer);
		}


		// ---The not-as-important-but-I-can't-abstract-them-away functions---
		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = originalTint;
		}

		protected override void StoreOriginalValue()
		{
			originalTint = spriteRendererRef.color;
		}

		protected override void SetToEndValue()
		{
			spriteRendererRef.color = endTint;
		}
	}
}
