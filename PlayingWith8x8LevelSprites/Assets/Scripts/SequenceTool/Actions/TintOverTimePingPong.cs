using UnityEngine;

namespace SequenceTool
{
	public class TintOverTimePingPong : OverTimePingPongAction
	{
		//Start value
		//End value
		//OnEnterStart value
		//OnEnterEnd value
		//Tween type
		//Return to start value after execution function
		//Loop + Pingpong (But probably in seperate classes for now)

		public SpriteRenderer spriteRendererRef;
		public Color startTint;
		public Color endTint;

		private Color onEnterStartTint;
		private Color onEnterEndTint;
		private Color onEnterSpriteTint;

		private void Update()
		{
			if (!isExecuting) { return; }

			UpdateColor();

			UpdatePingPongTimer();
			UpdateTimer();
		}

		private void UpdateColor()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, pingPongDuration, pingPongTimer);
			spriteRendererRef.color = Color.Lerp(startTint, endTint, normalizedTimer);
		}

		public override void StartAction()
		{
			base.StartAction();

			SaveOnEnterValues();

			onEnterSpriteTint = spriteRendererRef.color;
		}

		public override void EndAction()
		{
			base.EndAction();

			RestoreOnEnterValues();

			if (restoreOriginalValue)
			{
				RestoreOriginalValue();
			}
			else
			{
				spriteRendererRef.color = endTint;
			}
		}

		protected override void EndPingPong()
		{
			SwapStartAndEndColors();
		}

		private void SwapStartAndEndColors()
		{
			Color tempColor = startTint;
			startTint = endTint;
			endTint = tempColor;
		}

		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = onEnterSpriteTint;
		}

		protected override void SaveOnEnterValues()
		{
			onEnterStartTint = startTint;
			onEnterEndTint = endTint;
		}

		protected override void RestoreOnEnterValues()
		{
			startTint = onEnterStartTint;
			endTint = onEnterEndTint;
		}
	}
}