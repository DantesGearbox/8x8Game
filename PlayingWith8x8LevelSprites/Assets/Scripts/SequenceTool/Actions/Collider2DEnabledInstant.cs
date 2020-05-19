using UnityEngine;

namespace SequenceTool
{
	public class Collider2DEnabledInstant : InstantAction
	{
		public Collider2D colliderReference;

		public bool setToValue;
		
		protected override void SetToValue()
		{
			colliderReference.enabled = setToValue;
		}
	}
}