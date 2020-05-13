using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class GameObjectDestroyInstant : InstantAction
	{
		public GameObject gameObjectReference;

		protected override void SetToValue()
		{
			Destroy(gameObjectReference);
		}
	}
}