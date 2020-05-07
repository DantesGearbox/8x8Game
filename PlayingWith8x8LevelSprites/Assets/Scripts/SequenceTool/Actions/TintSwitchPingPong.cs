using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class TintSwitchPingPong : SwitchPingPongAction
	{
		public SpriteRenderer spriteRendererRef;
		public Color startTint;
		public Color endTint;
		
		private Color onEnterStartTint;
		private Color onEnterEndTint;
		private Color onEnterSpriteTint;

		private void Update()
		{
			if (!isExecuting) { return; }

			UpdatePingPongTimer();
			UpdateTimer();
		}

		public override void StartAction()
		{
			base.StartAction();

			SaveOnEnterValues();

			spriteRendererRef.color = startTint;
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

		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = onEnterSpriteTint;
		}

		protected override void EndPingPong()
		{
			spriteRendererRef.color = endTint;
			SwapStartAndEndColors();
		}

		private void SwapStartAndEndColors()
		{
			Color tempColor = startTint;
			startTint = endTint;
			endTint = tempColor;
		}

		protected override void RestoreOnEnterValues()
		{
			startTint = onEnterStartTint;
			endTint = onEnterEndTint;
		}

		protected override void SaveOnEnterValues()
		{
			onEnterSpriteTint = spriteRendererRef.color;
			onEnterStartTint = startTint;
			onEnterEndTint = endTint;
		}
	}
}
