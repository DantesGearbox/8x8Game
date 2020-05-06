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

			if (restoreAfterExecution)
			{
				onEnterStartTint = startTint;
				onEnterEndTint = endTint;
				onEnterSpriteTint = spriteRendererRef.color;
			}
		}

		public override void EndAction()
		{
			base.EndAction();

			if (restoreAfterExecution)
			{
				RestoreStartValueAfterExecution();
			}
			else
			{
				spriteRendererRef.color = endTint;
			}
		}

		protected override void EndPingPong()
		{
			//spriteRendererRef.color = endColor; //It may look weird without this, but it may also look weird with this
			SwapStartAndEndColors();
		}

		private void SwapStartAndEndColors()
		{
			Color tempColor = startTint;
			startTint = endTint;
			endTint = tempColor;
		}

		protected override void RestoreStartValueAfterExecution()
		{
			startTint = onEnterStartTint;
			endTint = onEnterEndTint;
			spriteRendererRef.color = onEnterSpriteTint;
		}
	}
}