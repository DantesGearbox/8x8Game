using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class GameObjectEnabledInstant : InstantAction
	{
		public GameObject GameObjectReference;

		public bool setToValue;

		protected override void SetToValue()
		{
			GameObjectReference.SetActive(setToValue);
		}
	}
}
