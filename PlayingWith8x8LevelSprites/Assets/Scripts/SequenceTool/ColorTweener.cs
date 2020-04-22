using UnityEngine;

//Note: 
// The loop and pingpong functions have some quirks. 
// It needs some more hours for it to work properly, but I'm leaving it as is for now.

public class ColorTweener : Tween
{
	public SpriteRenderer spriteRendererToTween;

	public Color startColor;
	public Color endColor;

	public bool loop = false;
	public float loopDuration = 0;
	private float loopTimer = 0;

	public bool pingpong = false;
	public float pingpongDuration = 0;
	private float pingpongTimer = 0;

	public bool instantTween = false; //This could definitely be an enum of different lerp types: lerp, instant, etc.
	
	private bool isTweening = false;

	//Loop: Go to max, reset, go again, until duration is over. One loop takes loopDuration time
	//Pingpong: Go to max, swap start and end, go again. One go takes pingpongDuration time

	private void Update()
	{
		if (!isTweening) { return; }

		if (!instantTween)
		{
			UpdateColorOverTime();
		}
		UpdateTimer();

		if (pingpong) { UpdatePingPongTimer(); }
		if (loop) { UpdateLoopTimer(); }
	}

	protected void UpdateTimer()
	{
		tweenTimer += Time.deltaTime;

		if (tweenTimer > tweenDuration)
		{
			StopTween();
			SetStartValueToEndValue(); //Make sure the current value gets to the max, even with slight lerp errors
		}
	}

	private void UpdatePingPongTimer()
	{
		pingpongTimer += Time.deltaTime;

		if(pingpongTimer > pingpongDuration)
		{
			pingpongTimer = 0;

			if (instantTween)
			{
				SetStartValueToEndValue();
			}

			SwapStartAndEndColors();
		}
	}

	private void SwapStartAndEndColors()
	{
		Color tempColor = startColor;
		startColor = endColor;
		endColor = tempColor;
	}

	private void UpdateLoopTimer()
	{
		loopTimer += Time.deltaTime;

		if(loopTimer > loopDuration)
		{
			loopTimer = 0;

			if (instantTween)
			{
				SetStartValueToEndValue();
				SwapStartAndEndColors();
			}
		}
	}

	private void UpdateColorOverTime()
	{
		//Use the relevant timer (Normal/Loop/Pingpong)
		float normalizedTimer = NormalizeTo01Scale(0, tweenDuration, tweenTimer);
		if (loop)
		{
			normalizedTimer = NormalizeTo01Scale(0, loopDuration, loopTimer);
		}
		if (pingpong)
		{
			normalizedTimer = NormalizeTo01Scale(0, pingpongDuration, pingpongTimer);
		}

		spriteRendererToTween.color = Color.Lerp(startColor, endColor, normalizedTimer);
	}

	private void SetStartValueToEndValue()
	{
		spriteRendererToTween.color = endColor;
	}

	public override void StartTween()
	{
		isTweening = true;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
		pingpongTimer = 0;
		loopTimer = 0;
	}
}
