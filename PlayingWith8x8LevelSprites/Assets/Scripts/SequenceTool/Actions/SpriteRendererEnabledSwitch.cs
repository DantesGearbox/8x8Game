using UnityEngine;

namespace SequenceTool
{
	public class SpriteRendererEnabledSwitch : SwitchAction
	{
		public SpriteRenderer spriteRendererReference;

		public bool startValue;
		public bool endValue;

		private bool onEnterValue;

		protected override void RestoreOriginalValue()
		{
			spriteRendererReference.enabled = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			spriteRendererReference.enabled = endValue;
		}

		protected override void SetToStartValue()
		{
			spriteRendererReference.enabled = startValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = spriteRendererReference.enabled;
		}
	}
}