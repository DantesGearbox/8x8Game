using UnityEngine;

public class ColorPingPongTweener : Tween
{
	public SpriteRenderer spriteRendererToTween;

	public Color startColor;
	public Color endColor;
	public Color startColorOnEnter;
	public Color endColorOnEnter;

	public float pingpongDuration = 0;
	private float pingpongTimer = 0;

	public bool instantTransition = false;

	private bool isTweening = false;
	
	private void Update()
	{
		if (!isTweening) { return; }

		if (!instantTransition)
		{
			UpdateColorOverTime();
		}

		UpdatePingPongTimer();
		UpdateTimer();
	}

	protected void UpdateTimer()
	{
		tweenTimer += Time.deltaTime;

		if (tweenTimer > tweenDuration)
		{
			StopTween();
			ResetColor();
		}
	}

	private void UpdatePingPongTimer()
	{
		pingpongTimer += Time.deltaTime;

		if(pingpongTimer > pingpongDuration)
		{
			pingpongTimer = 0;
			spriteRendererToTween.color = endColor;
			SwapStartAndEndColors();
		}
	}

	private void SwapStartAndEndColors()
	{
		Color tempColor = startColor;
		startColor = endColor;
		endColor = tempColor;

	}

	private void UpdateColorOverTime()
	{
		float normalizedTimer = NormalizeTo01Scale(0, pingpongDuration, pingpongTimer);
		spriteRendererToTween.color = Color.Lerp(startColor, endColor, normalizedTimer);
	}

	private void ResetColor()
	{
		spriteRendererToTween.color = startColorOnEnter;
	}

	public override void StartTween()
	{
		isTweening = true;
		startColorOnEnter = startColor;
		endColorOnEnter = endColor;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
		pingpongTimer = 0;
		startColor = startColorOnEnter;
		endColor = endColorOnEnter;
	}
}
