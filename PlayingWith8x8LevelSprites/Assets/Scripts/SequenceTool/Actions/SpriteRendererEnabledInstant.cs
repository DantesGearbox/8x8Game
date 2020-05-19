using UnityEngine;

namespace SequenceTool
{
	public class SpriteRendererEnabledInstant : InstantAction
	{
		public SpriteRenderer spriteRendererReference;

		public bool setToValue;
		
		protected override void SetToValue()
		{
			spriteRendererReference.enabled = setToValue;
		}
	}
}