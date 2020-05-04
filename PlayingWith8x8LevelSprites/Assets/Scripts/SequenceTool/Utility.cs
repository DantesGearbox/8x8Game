using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public static class Utility
	{
		public static float NormalizeTo01Scale(float startVal, float maxVal, float currVal)
		{
			float nonOffsetValue = currVal - startVal;
			float nonOffsetMaxValue = maxVal - startVal;

			float normalizedValue = nonOffsetValue / nonOffsetMaxValue;

			return normalizedValue;
		}
	}
}
