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

		protected override void SwapStartAndEndValues()
		{
			Color tempColor = startTint;
			startTint = endTint;
			endTint = tempColor;
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

		protected override void StoreOriginalValue()
		{
			onEnterSpriteTint = spriteRendererRef.color;
		}

		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = onEnterSpriteTint;
		}

		protected override void SetToEndValue()
		{
			spriteRendererRef.color = endTint;
		}

		protected override void SetToStartValue()
		{
			spriteRendererRef.color = startTint;
		}
	}
}
