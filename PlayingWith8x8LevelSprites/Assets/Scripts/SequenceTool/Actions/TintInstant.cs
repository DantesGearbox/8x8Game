using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class TintInstant : InstantAction
	{
		public SpriteRenderer spriteRendererRef;
		public Color setToTint;

		protected override void SetToValue()
		{
			spriteRendererRef.color = setToTint;
		}
	}
}
