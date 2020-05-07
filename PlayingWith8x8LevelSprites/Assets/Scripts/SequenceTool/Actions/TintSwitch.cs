using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class TintSwitch : SwitchAction
	{
		public SpriteRenderer spriteRendererRef;
		public Color startTint;
		public Color endTint;

		private Color onEnterSpriteTint;

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
