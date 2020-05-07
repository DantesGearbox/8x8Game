using UnityEngine;

namespace SequenceTool
{
	public class TintOverTimePingPong : OverTimePingPongAction
	{

		public SpriteRenderer spriteRendererRef;
		public Color startTint;
		public Color endTint;

		private Color onEnterStartTint;
		private Color onEnterEndTint;
		private Color onEnterSpriteTint;

		// ---The one actually-important function---
		protected override void UpdateValue()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, pingPongDuration, pingPongTimer);
			spriteRendererRef.color = Color.Lerp(startTint, endTint, normalizedTimer);
		}

		// ---The not-as-important-but-I-can't-abstract-them-away functions---
		protected override void SwapStartAndEndValues()
		{
			Color tempColor = startTint;
			startTint = endTint;
			endTint = tempColor;
		}

		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = onEnterSpriteTint;
		}

		protected override void StoreOnEnterValues()
		{
			onEnterStartTint = startTint;
			onEnterEndTint = endTint;
		}

		protected override void RestoreOnEnterValues()
		{
			startTint = onEnterStartTint;
			endTint = onEnterEndTint;
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