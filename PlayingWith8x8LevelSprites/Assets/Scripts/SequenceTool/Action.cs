using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public abstract class Action : MonoBehaviour
	{
		[HideInInspector] public bool hasExecuted = false;
		[HideInInspector] public bool isExecuting = false;

		public float startingTime = 0;

		public abstract void StartAction();
		public abstract void StopAction();
	}
}
