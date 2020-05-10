using UnityEngine;

namespace SequenceTool
{
	public class SpriteChangeInstant : InstantAction
	{
		public SpriteRenderer spriteRendererRef;
		public Sprite spriteToChangeTo;

		protected override void SetToValue()
		{
			spriteRendererRef.sprite = spriteToChangeTo;
		}
	}
}