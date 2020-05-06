using UnityEngine;

namespace SequenceTool
{
	public class ColorOverTimeLoop : OverTimeLoopAction
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
		private Color onEnterSpriteColor;

		private void Update()
		{
			if (!isExecuting) { return; }

			UpdateColor();

			UpdateLoopTimer();
			UpdateTimer();
		}

		private void UpdateColor()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, loopDuration, loopTimer);
			spriteRendererRef.color = Color.Lerp(startColor, endColor, normalizedTimer);
		}

		public override void StartAction()
		{
			base.StartAction();

			if (restoreAfterExecution)
			{
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

		protected override void EndLoop()
		{
			spriteRendererRef.color = endColor;
		}

		protected override void RestoreStartValueAfterExecution()
		{
			spriteRendererRef.color = onEnterSpriteColor;
		}
	}

}