using UnityEngine;

namespace SequenceTool
{
	public class ColliderEnabledInstant : InstantAction
	{
		public Collider colliderReference;

		public bool setToValue;
		
		protected override void SetToValue()
		{
			colliderReference.enabled = setToValue;
		}
	}
}