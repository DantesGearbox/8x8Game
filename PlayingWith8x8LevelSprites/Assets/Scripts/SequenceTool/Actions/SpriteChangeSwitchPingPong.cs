using UnityEngine;

namespace SequenceTool
{
	public class SpriteChangeSwitchPingPong : SwitchPingPongAction
	{
		public SpriteRenderer spriteRendererRef;
		public Sprite startSprite;
		public Sprite endSprite;

		private Sprite onEnterStartSprite;
		private Sprite onEnterEndSprite;
		private Sprite onEnterSprite;

		protected override void RestoreOnEnterValues()
		{
			startSprite = onEnterStartSprite;
			endSprite = onEnterEndSprite;
		}

		protected override void RestoreOriginalValue()
		{
			spriteRendererRef.sprite = onEnterSprite;
		}

		protected override void SaveOnEnterValues()
		{
			onEnterStartSprite = startSprite;
			onEnterEndSprite = endSprite;
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
			onEnterSprite = spriteRendererRef.sprite;
		}

		protected override void SwapStartAndEndValues()
		{
			Sprite tempSprite = startSprite;
			startSprite = endSprite;
			endSprite = tempSprite;
		}
	}
}