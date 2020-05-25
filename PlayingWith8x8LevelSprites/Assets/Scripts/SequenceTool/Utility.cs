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

		//public static float NormalizeTo01ScaleVector3(Vector3 startVal, Vector3 maxVal, Vector3 currVal)
		//{
		//	float nonOffsetValue = currVal - startVal;
		//	float nonOffsetMaxValue = maxVal - startVal;

		//	float normalizedValue = nonOffsetValue / nonOffsetMaxValue;

		//	return normalizedValue;
		//}

		//Not functional
		//public static Vector2 NormalizeTo01ScaleVector2(Vector2 startVal, Vector2 maxVal, Vector2 currVal)
		//{
		//	Vector2 nonOffsetValue = currVal - startVal;
		//	Vector2 nonOffsetMaxValue = maxVal - startVal;

		//	Vector2 normalizedValue = nonOffsetValue / nonOffsetMaxValue;

		//	return normalizedValue;
		//}
	}
}
