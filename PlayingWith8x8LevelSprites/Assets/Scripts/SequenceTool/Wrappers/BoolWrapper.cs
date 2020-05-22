using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class BoolWrapper : MonoBehaviour
	{
		public bool boolValue;

		//To make it alright to write if(BoolWrapper). All other still have to explicitly use BoolWrapper.BoolValue.
		public static implicit operator bool(BoolWrapper b)
		{
			bool returnBool = b.boolValue;
			return returnBool;
		}
	}
}