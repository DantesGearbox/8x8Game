using UnityEngine;

namespace SequenceTool
{
	public class ColliderEnabledSwitch : SwitchAction
	{
		public Collider colliderReference;

		public bool startValue;
		public bool endValue;

		private bool onEnterValue;

		protected override void RestoreOriginalValue()
		{
			colliderReference.enabled = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			colliderReference.enabled = endValue;
		}

		protected override void SetToStartValue()
		{
			colliderReference.enabled = startValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = colliderReference.enabled;
		}
	}
}