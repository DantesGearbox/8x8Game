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

		private void Update()
		{
			if (!isExecuting) { return; }

			UpdateTimer();
		}

		public override void StartAction()
		{
			base.StartAction();

			if (restoreOriginalValue)
			{
				onEnterSpriteTint = spriteRendererRef.color;
			}

			spriteRendererRef.color = startTint;
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

		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.color = onEnterSpriteTint;
		}
	}
}
