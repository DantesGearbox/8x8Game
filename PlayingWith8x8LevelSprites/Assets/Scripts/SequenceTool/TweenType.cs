using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class TweenType : MonoBehaviour
	{
		public enum TweenTypes
		{
			notUsed, linear, easeOutQuad, easeInQuad, easeInOutQuad, easeInCubic, easeOutCubic, easeInOutCubic, easeInQuart, easeOutQuart, easeInOutQuart,
			easeInQuint, easeOutQuint, easeInOutQuint, easeInSine, easeOutSine, easeInOutSine, easeInExpo, easeOutExpo, easeInOutExpo, easeInCirc, easeOutCirc, easeInOutCirc,
			easeInBounce, easeOutBounce, easeInOutBounce, easeInBack, easeOutBack, easeInOutBack, easeInElastic, easeOutElastic, easeInOutElastic, easeSpring, easeShake, punch,
			once, clamp, pingPong, animationCurve
		}

		public static float easeOutQuadOpt(float start, float diff, float ratioPassed)
		{
			return -diff * ratioPassed * (ratioPassed - 2) + start;
		}

		public static float easeInQuadOpt(float start, float diff, float ratioPassed)
		{
			return diff * ratioPassed * ratioPassed + start;
		}

		public static float easeInOutQuadOpt(float start, float diff, float ratioPassed)
		{
			ratioPassed /= .5f;
			if (ratioPassed < 1) return diff / 2 * ratioPassed * ratioPassed + start;
			ratioPassed--;
			return -diff / 2 * (ratioPassed * (ratioPassed - 2) - 1) + start;
		}

		public static Vector3 easeInOutQuadOpt(Vector3 start, Vector3 diff, float ratioPassed)
		{
			ratioPassed /= .5f;
			if (ratioPassed < 1) return diff / 2 * ratioPassed * ratioPassed + start;
			ratioPassed--;
			return -diff / 2 * (ratioPassed * (ratioPassed - 2) - 1) + start;
		}

		public static float linear(float start, float end, float val)
		{
			return Mathf.Lerp(start, end, val);
		}

		public static float clerp(float start, float end, float val)
		{
			float min = 0.0f;
			float max = 360.0f;
			float half = Mathf.Abs((max - min) / 2.0f);
			float retval = 0.0f;
			float diff = 0.0f;
			if ((end - start) < -half)
			{
				diff = ((max - start) + end) * val;
				retval = start + diff;
			}
			else if ((end - start) > half)
			{
				diff = -((max - end) + start) * val;
				retval = start + diff;
			}
			else retval = start + (end - start) * val;
			return retval;
		}

		public static float spring(float start, float end, float val)
		{
			val = Mathf.Clamp01(val);
			val = (Mathf.Sin(val * Mathf.PI * (0.2f + 2.5f * val * val * val)) * Mathf.Pow(1f - val, 2.2f) + val) * (1f + (1.2f * (1f - val)));
			return start + (end - start) * val;
		}

		public static float easeInQuad(float start, float end, float val)
		{
			end -= start;
			return end * val * val + start;
		}

		public static float easeOutQuad(float start, float end, float val)
		{
			end -= start;
			return -end * val * (val - 2) + start;
		}

		public static float easeInOutQuad(float start, float end, float val)
		{
			val /= .5f;
			end -= start;
			if (val < 1) return end / 2 * val * val + start;
			val--;
			return -end / 2 * (val * (val - 2) - 1) + start;
		}


		public static float easeInOutQuadOpt2(float start, float diffBy2, float val, float val2)
		{
			val /= .5f;
			if (val < 1) return diffBy2 * val2 + start;
			val--;
			return -diffBy2 * ((val2 - 2) - 1f) + start;
		}

		public static float easeInCubic(float start, float end, float val)
		{
			end -= start;
			return end * val * val * val + start;
		}

		public static float easeOutCubic(float start, float end, float val)
		{
			val--;
			end -= start;
			return end * (val * val * val + 1) + start;
		}

		public static float easeInOutCubic(float start, float end, float val)
		{
			val /= .5f;
			end -= start;
			if (val < 1) return end / 2 * val * val * val + start;
			val -= 2;
			return end / 2 * (val * val * val + 2) + start;
		}

		public static float easeInQuart(float start, float end, float val)
		{
			end -= start;
			return end * val * val * val * val + start;
		}

		public static float easeOutQuart(float start, float end, float val)
		{
			val--;
			end -= start;
			return -end * (val * val * val * val - 1) + start;
		}

		public static float easeInOutQuart(float start, float end, float val)
		{
			val /= .5f;
			end -= start;
			if (val < 1) return end / 2 * val * val * val * val + start;
			val -= 2;
			return -end / 2 * (val * val * val * val - 2) + start;
		}

		public static float easeInQuint(float start, float end, float val)
		{
			end -= start;
			return end * val * val * val * val * val + start;
		}

		public static float easeOutQuint(float start, float end, float val)
		{
			val--;
			end -= start;
			return end * (val * val * val * val * val + 1) + start;
		}

		public static float easeInOutQuint(float start, float end, float val)
		{
			val /= .5f;
			end -= start;
			if (val < 1) return end / 2 * val * val * val * val * val + start;
			val -= 2;
			return end / 2 * (val * val * val * val * val + 2) + start;
		}

		public static float easeInSine(float start, float end, float val)
		{
			end -= start;
			return -end * Mathf.Cos(val / 1 * (Mathf.PI / 2)) + end + start;
		}

		public static float easeOutSine(float start, float end, float val)
		{
			end -= start;
			return end * Mathf.Sin(val / 1 * (Mathf.PI / 2)) + start;
		}

		public static float easeInOutSine(float start, float end, float val)
		{
			end -= start;
			return -end / 2 * (Mathf.Cos(Mathf.PI * val / 1) - 1) + start;
		}

		public static float easeInExpo(float start, float end, float val)
		{
			end -= start;
			return end * Mathf.Pow(2, 10 * (val / 1 - 1)) + start;
		}

		public static float easeOutExpo(float start, float end, float val)
		{
			end -= start;
			return end * (-Mathf.Pow(2, -10 * val / 1) + 1) + start;
		}

		public static float easeInOutExpo(float start, float end, float val)
		{
			val /= .5f;
			end -= start;
			if (val < 1) return end / 2 * Mathf.Pow(2, 10 * (val - 1)) + start;
			val--;
			return end / 2 * (-Mathf.Pow(2, -10 * val) + 2) + start;
		}

		public static float easeInCirc(float start, float end, float val)
		{
			end -= start;
			return -end * (Mathf.Sqrt(1 - val * val) - 1) + start;
		}

		public static float easeOutCirc(float start, float end, float val)
		{
			val--;
			end -= start;
			return end * Mathf.Sqrt(1 - val * val) + start;
		}

		public static float easeInOutCirc(float start, float end, float val)
		{
			val /= .5f;
			end -= start;
			if (val < 1) return -end / 2 * (Mathf.Sqrt(1 - val * val) - 1) + start;
			val -= 2;
			return end / 2 * (Mathf.Sqrt(1 - val * val) + 1) + start;
		}

		public static float easeInBounce(float start, float end, float val)
		{
			end -= start;
			float d = 1f;
			return end - easeOutBounce(0, end, d - val) + start;
		}

		public static float easeOutBounce(float start, float end, float val)
		{
			val /= 1f;
			end -= start;
			if (val < (1 / 2.75f))
			{
				return end * (7.5625f * val * val) + start;
			}
			else if (val < (2 / 2.75f))
			{
				val -= (1.5f / 2.75f);
				return end * (7.5625f * (val) * val + .75f) + start;
			}
			else if (val < (2.5 / 2.75))
			{
				val -= (2.25f / 2.75f);
				return end * (7.5625f * (val) * val + .9375f) + start;
			}
			else
			{
				val -= (2.625f / 2.75f);
				return end * (7.5625f * (val) * val + .984375f) + start;
			}
		}

		public static float easeInOutBounce(float start, float end, float val)
		{
			end -= start;
			float d = 1f;
			if (val < d / 2) return easeInBounce(0, end, val * 2) * 0.5f + start;
			else return easeOutBounce(0, end, val * 2 - d) * 0.5f + end * 0.5f + start;
		}

		public static float easeInBack(float start, float end, float val, float overshoot = 1.0f)
		{
			end -= start;
			val /= 1;
			float s = 1.70158f * overshoot;
			return end * (val) * val * ((s + 1) * val - s) + start;
		}

		public static float easeOutBack(float start, float end, float val, float overshoot = 1.0f)
		{
			float s = 1.70158f * overshoot;
			end -= start;
			val = (val / 1) - 1;
			return end * ((val) * val * ((s + 1) * val + s) + 1) + start;
		}

		public static float easeInOutBack(float start, float end, float val, float overshoot = 1.0f)
		{
			float s = 1.70158f * overshoot;
			end -= start;
			val /= .5f;
			if ((val) < 1)
			{
				s *= (1.525f) * overshoot;
				return end / 2 * (val * val * (((s) + 1) * val - s)) + start;
			}
			val -= 2;
			s *= (1.525f) * overshoot;
			return end / 2 * ((val) * val * (((s) + 1) * val + s) + 2) + start;
		}

		public static float easeInElastic(float start, float end, float val, float overshoot = 1.0f, float period = 0.3f)
		{
			end -= start;

			float p = period;
			float s = 0f;
			float a = 0f;

			if (val == 0f) return start;

			if (val == 1f) return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4f;
			}
			else
			{
				s = p / (2f * Mathf.PI) * Mathf.Asin(end / a);
			}

			if (overshoot > 1f && val > 0.6f)
				overshoot = 1f + ((1f - val) / 0.4f * (overshoot - 1f));
			// Debug.Log("ease in elastic val:"+val+" a:"+a+" overshoot:"+overshoot);

			val = val - 1f;
			return start - (a * Mathf.Pow(2f, 10f * val) * Mathf.Sin((val - s) * (2f * Mathf.PI) / p)) * overshoot;
		}

		public static float easeOutElastic(float start, float end, float val, float overshoot = 1.0f, float period = 0.3f)
		{
			end -= start;

			float p = period;
			float s = 0f;
			float a = 0f;

			if (val == 0f) return start;

			// Debug.Log("ease out elastic val:"+val+" a:"+a);
			if (val == 1f) return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4f;
			}
			else
			{
				s = p / (2f * Mathf.PI) * Mathf.Asin(end / a);
			}
			if (overshoot > 1f && val < 0.4f)
				overshoot = 1f + (val / 0.4f * (overshoot - 1f));
			// Debug.Log("ease out elastic val:"+val+" a:"+a+" overshoot:"+overshoot);

			return start + end + a * Mathf.Pow(2f, -10f * val) * Mathf.Sin((val - s) * (2f * Mathf.PI) / p) * overshoot;
		}

		public static float easeInOutElastic(float start, float end, float val, float overshoot = 1.0f, float period = 0.3f)
		{
			end -= start;

			float p = period;
			float s = 0f;
			float a = 0f;

			if (val == 0f) return start;

			val = val / (1f / 2f);
			if (val == 2f) return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4f;
			}
			else
			{
				s = p / (2f * Mathf.PI) * Mathf.Asin(end / a);
			}

			if (overshoot > 1f)
			{
				if (val < 0.2f)
				{
					overshoot = 1f + (val / 0.2f * (overshoot - 1f));
				}
				else if (val > 0.8f)
				{
					overshoot = 1f + ((1f - val) / 0.2f * (overshoot - 1f));
				}
			}

			if (val < 1f)
			{
				val = val - 1f;
				return start - 0.5f * (a * Mathf.Pow(2f, 10f * val) * Mathf.Sin((val - s) * (2f * Mathf.PI) / p)) * overshoot;
			}
			val = val - 1f;
			return end + start + a * Mathf.Pow(2f, -10f * val) * Mathf.Sin((val - s) * (2f * Mathf.PI) / p) * 0.5f * overshoot;
		}


		//// Vector3 Ease Methods

		//private Vector3 easeInOutQuad()
		//{
		//	val = this.ratioPassed * 2f;

		//	if (val < 1f)
		//	{
		//		val = val * val;
		//		return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//	}
		//	val = (1f - val) * (val - 3f) + 1f;
		//	return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//}

		//private Vector3 easeInQuad()
		//{
		//	val = ratioPassed * ratioPassed;
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeOutQuad()
		//{
		//	val = this.ratioPassed;
		//	val = -val * (val - 2f);
		//	return (this.diff * val + this.from);
		//}

		//private Vector3 easeLinear()
		//{
		//	val = this.ratioPassed;
		//	return new Vector3(this.from.x + this.diff.x * val, this.from.y + this.diff.y * val, this.from.z + this.diff.z * val);
		//}

		//private Vector3 easeSpring()
		//{
		//	val = Mathf.Clamp01(this.ratioPassed);
		//	val = (Mathf.Sin(val * Mathf.PI * (0.2f + 2.5f * val * val * val)) * Mathf.Pow(1f - val, 2.2f) + val) * (1f + (1.2f * (1f - val)));
		//	return this.from + this.diff * val;
		//}

		//private Vector3 easeInCubic()
		//{
		//	val = this.ratioPassed * this.ratioPassed * this.ratioPassed;
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeOutCubic()
		//{
		//	val = this.ratioPassed - 1f;
		//	val = (val * val * val + 1);
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeInOutCubic()
		//{
		//	val = this.ratioPassed * 2f;
		//	if (val < 1f)
		//	{
		//		val = val * val * val;
		//		return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//	}
		//	val -= 2f;
		//	val = val * val * val + 2f;
		//	return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//}

		//private Vector3 easeInQuart()
		//{
		//	val = this.ratioPassed * this.ratioPassed * this.ratioPassed * this.ratioPassed;
		//	return diff * val + this.from;
		//}

		//private Vector3 easeOutQuart()
		//{
		//	val = this.ratioPassed - 1f;
		//	val = -(val * val * val * val - 1);
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeInOutQuart()
		//{
		//	val = this.ratioPassed * 2f;
		//	if (val < 1f)
		//	{
		//		val = val * val * val * val;
		//		return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//	}
		//	val -= 2f;
		//	//		val = (val * val * val * val - 2f);
		//	return -this.diffDiv2 * (val * val * val * val - 2f) + this.from;
		//}

		//private Vector3 easeInQuint()
		//{
		//	val = this.ratioPassed;
		//	val = val * val * val * val * val;
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeOutQuint()
		//{
		//	val = this.ratioPassed - 1f;
		//	val = (val * val * val * val * val + 1f);
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeInOutQuint()
		//{
		//	val = this.ratioPassed * 2f;
		//	if (val < 1f)
		//	{
		//		val = val * val * val * val * val;
		//		return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//	}
		//	val -= 2f;
		//	val = (val * val * val * val * val + 2f);
		//	return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//}

		//private Vector3 easeInSine()
		//{
		//	val = -Mathf.Cos(this.ratioPassed * LeanTween.PI_DIV2);
		//	return new Vector3(this.diff.x * val + this.diff.x + this.from.x, this.diff.y * val + this.diff.y + this.from.y, this.diff.z * val + this.diff.z + this.from.z);
		//}

		//private Vector3 easeOutSine()
		//{
		//	val = Mathf.Sin(this.ratioPassed * LeanTween.PI_DIV2);
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeInOutSine()
		//{
		//	val = -(Mathf.Cos(Mathf.PI * this.ratioPassed) - 1f);
		//	return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//}

		//private Vector3 easeInExpo()
		//{
		//	val = Mathf.Pow(2f, 10f * (this.ratioPassed - 1f));
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeOutExpo()
		//{
		//	val = (-Mathf.Pow(2f, -10f * this.ratioPassed) + 1f);
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeInOutExpo()
		//{
		//	val = this.ratioPassed * 2f;
		//	if (val < 1) return this.diffDiv2 * Mathf.Pow(2, 10 * (val - 1)) + this.from;
		//	val--;
		//	return this.diffDiv2 * (-Mathf.Pow(2, -10 * val) + 2) + this.from;
		//}

		//private Vector3 easeInCirc()
		//{
		//	val = -(Mathf.Sqrt(1f - this.ratioPassed * this.ratioPassed) - 1f);
		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeOutCirc()
		//{
		//	val = this.ratioPassed - 1f;
		//	val = Mathf.Sqrt(1f - val * val);

		//	return new Vector3(this.diff.x * val + this.from.x, this.diff.y * val + this.from.y, this.diff.z * val + this.from.z);
		//}

		//private Vector3 easeInOutCirc()
		//{
		//	val = this.ratioPassed * 2f;
		//	if (val < 1f)
		//	{
		//		val = -(Mathf.Sqrt(1f - val * val) - 1f);
		//		return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//	}
		//	val -= 2f;
		//	val = (Mathf.Sqrt(1f - val * val) + 1f);
		//	return new Vector3(this.diffDiv2.x * val + this.from.x, this.diffDiv2.y * val + this.from.y, this.diffDiv2.z * val + this.from.z);
		//}

		//private Vector3 easeInBounce()
		//{
		//	val = this.ratioPassed;
		//	val = 1f - val;
		//	return new Vector3(this.diff.x - LeanTween.easeOutBounce(0, this.diff.x, val) + this.from.x,
		//		this.diff.y - LeanTween.easeOutBounce(0, this.diff.y, val) + this.from.y,
		//		this.diff.z - LeanTween.easeOutBounce(0, this.diff.z, val) + this.from.z);
		//}

		//private Vector3 easeOutBounce()
		//{
		//	val = ratioPassed;
		//	float valM, valN; // bounce values
		//	if (val < (valM = 1 - 1.75f * this.overshoot / 2.75f))
		//	{
		//		val = 1 / valM / valM * val * val;
		//	}
		//	else if (val < (valN = 1 - .75f * this.overshoot / 2.75f))
		//	{
		//		val -= (valM + valN) / 2;
		//		// first bounce, height: 1/4
		//		val = 7.5625f * val * val + 1 - .25f * this.overshoot * this.overshoot;
		//	}
		//	else if (val < (valM = 1 - .25f * this.overshoot / 2.75f))
		//	{
		//		val -= (valM + valN) / 2;
		//		// second bounce, height: 1/16
		//		val = 7.5625f * val * val + 1 - .0625f * this.overshoot * this.overshoot;
		//	}
		//	else
		//	{ // valN = 1
		//		val -= (valM + 1) / 2;
		//		// third bounce, height: 1/64
		//		val = 7.5625f * val * val + 1 - .015625f * this.overshoot * this.overshoot;
		//	}
		//	return this.diff * val + this.from;
		//}

		//private Vector3 easeInOutBounce()
		//{
		//	val = this.ratioPassed * 2f;
		//	if (val < 1f)
		//	{
		//		return new Vector3(LeanTween.easeInBounce(0, this.diff.x, val) * 0.5f + this.from.x,
		//			LeanTween.easeInBounce(0, this.diff.y, val) * 0.5f + this.from.y,
		//			LeanTween.easeInBounce(0, this.diff.z, val) * 0.5f + this.from.z);
		//	}
		//	else
		//	{
		//		val = val - 1f;
		//		return new Vector3(LeanTween.easeOutBounce(0, this.diff.x, val) * 0.5f + this.diffDiv2.x + this.from.x,
		//			LeanTween.easeOutBounce(0, this.diff.y, val) * 0.5f + this.diffDiv2.y + this.from.y,
		//			LeanTween.easeOutBounce(0, this.diff.z, val) * 0.5f + this.diffDiv2.z + this.from.z);
		//	}
		//}

		//private Vector3 easeInBack()
		//{
		//	val = this.ratioPassed;
		//	val /= 1;
		//	float s = 1.70158f * this.overshoot;
		//	return this.diff * (val) * val * ((s + 1) * val - s) + this.from;
		//}

		//private Vector3 easeOutBack()
		//{
		//	float s = 1.70158f * this.overshoot;
		//	val = (this.ratioPassed / 1) - 1;
		//	val = ((val) * val * ((s + 1) * val + s) + 1);
		//	return this.diff * val + this.from;
		//}

		//private Vector3 easeInOutBack()
		//{
		//	float s = 1.70158f * this.overshoot;
		//	val = this.ratioPassed * 2f;
		//	if ((val) < 1)
		//	{
		//		s *= (1.525f) * overshoot;
		//		return this.diffDiv2 * (val * val * (((s) + 1) * val - s)) + this.from;
		//	}
		//	val -= 2;
		//	s *= (1.525f) * overshoot;
		//	val = ((val) * val * (((s) + 1) * val + s) + 2);
		//	return this.diffDiv2 * val + this.from;
		//}

		//private Vector3 easeInElastic()
		//{
		//	return new Vector3(LeanTween.easeInElastic(this.from.x, this.to.x, this.ratioPassed, this.overshoot, this.period),
		//		LeanTween.easeInElastic(this.from.y, this.to.y, this.ratioPassed, this.overshoot, this.period),
		//		LeanTween.easeInElastic(this.from.z, this.to.z, this.ratioPassed, this.overshoot, this.period));
		//}

		//private Vector3 easeOutElastic()
		//{
		//	return new Vector3(LeanTween.easeOutElastic(this.from.x, this.to.x, this.ratioPassed, this.overshoot, this.period),
		//		LeanTween.easeOutElastic(this.from.y, this.to.y, this.ratioPassed, this.overshoot, this.period),
		//		LeanTween.easeOutElastic(this.from.z, this.to.z, this.ratioPassed, this.overshoot, this.period));
		//}

		//private Vector3 easeInOutElastic()
		//{
		//	return new Vector3(LeanTween.easeInOutElastic(this.from.x, this.to.x, this.ratioPassed, this.overshoot, this.period),
		//		LeanTween.easeInOutElastic(this.from.y, this.to.y, this.ratioPassed, this.overshoot, this.period),
		//		LeanTween.easeInOutElastic(this.from.z, this.to.z, this.ratioPassed, this.overshoot, this.period));
		//}
	}
}
