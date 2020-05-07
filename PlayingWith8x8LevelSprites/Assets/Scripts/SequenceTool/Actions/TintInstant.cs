using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class TintInstant : InstantAction
	{
		public SpriteRenderer spriteRendererRef;
		public Color setToTint;

		public override void StartAction()
		{
			base.StartAction();

			spriteRendererRef.color = setToTint;
		}
	}
}
