using UnityEngine;

namespace SequenceTool
{
	public class ColorOverTimePingPong : OverTimePingPongAction
	{
		//Start value
		//End value
		//OnEnterStart value
		//OnEnterEnd value
		//Tween type
		//Return to start value after execution function
		//Loop + Pingpong (But probably in seperate classes for now)

		public SpriteRenderer spriteRendererRef;
		public Color startColor;
		public Color endColor;

		private Color onEnterStartColor;
		private Color onEnterEndColor;
		private Color onEnterSpriteColor;

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
			spriteRendererRef.color = Color.Lerp(startColor, endColor, normalizedTimer);
		}

		public override void StartAction()
		{
			base.StartAction();

			if (restoreAfterExecution)
			{
				onEnterStartColor = startColor;
				onEnterEndColor = endColor;
				onEnterSpriteColor = spriteRendererRef.color;
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
				spriteRendererRef.color = endColor;
			}
		}

		protected override void EndPingPong()
		{
			//spriteRendererRef.color = endColor; //It may look weird without this, but it may also look weird with this
			SwapStartAndEndColors();
		}

		private void SwapStartAndEndColors()
		{
			Color tempColor = startColor;
			startColor = endColor;
			endColor = tempColor;
		}

		protected override void RestoreStartValueAfterExecution()
		{
			startColor = onEnterStartColor;
			endColor = onEnterEndColor;
			spriteRendererRef.color = onEnterSpriteColor;
		}
	}
}