using UnityEngine;

namespace SequenceTool
{
	public class TintOverTimeLoop : OverTimeLoopAction
	{
		public SpriteRenderer spriteRendererRef;
		public Color startTint;
		public Color endTint;
		private Color onEnterSpriteTint;

		protected override void UpdateValue()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, loopDuration, loopTimer);
			spriteRendererRef.color = Color.Lerp(startTint, endTint, normalizedTimer);
		}


		// ---The not-as-important-but-I-can't-abstract-them-away functions---
		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = onEnterSpriteTint;
		}

		protected override void StoreOriginalValue()
		{
			onEnterSpriteTint = spriteRendererRef.color;
		}

		protected override void SetToEndValue()
		{
			spriteRendererRef.color = endTint;
		}

		
	}

}