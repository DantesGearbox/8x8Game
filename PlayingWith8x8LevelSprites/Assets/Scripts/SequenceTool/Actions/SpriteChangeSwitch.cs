using UnityEngine;

namespace SequenceTool
{
	public class SpriteChangeSwitch : SwitchAction
	{
		public SpriteRenderer spriteRendererRef;
		public Sprite startSprite;
		public Sprite endSprite;

		private Sprite onEnterSprite;

		protected override void RestoreOriginalValue()
		{
			onEnterSprite = spriteRendererRef.sprite;
		}

		protected override void SetToEndValue()
		{
			spriteRendererRef.sprite = endSprite;
		}

		protected override void SetToStartValue()
		{
			spriteRendererRef.sprite = startSprite;
		}

		protected override void StoreOriginalValue()
		{
			spriteRendererRef.sprite = onEnterSprite;
		}
	}
}