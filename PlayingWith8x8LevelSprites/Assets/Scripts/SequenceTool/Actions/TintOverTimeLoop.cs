using UnityEngine;

namespace SequenceTool
{
	public class TintOverTimeLoop : OverTimeLoopAction
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
		private Color onEnterSpriteTint;

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
			spriteRendererRef.color = Color.Lerp(startTint, endTint, normalizedTimer);
		}

		public override void StartAction()
		{
			base.StartAction();

			if (restoreOriginalValue)
			{
				onEnterSpriteTint = spriteRendererRef.color;
			}
		}

		public override void EndAction()
		{
			base.EndAction();

			if (restoreOriginalValue)
			{
				RestoreOriginalValue();
			}
			else
			{
				spriteRendererRef.color = endTint;
			}
		}

		protected override void EndLoop()
		{
			spriteRendererRef.color = endTint;
		}

		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = onEnterSpriteTint;
		}
	}

}