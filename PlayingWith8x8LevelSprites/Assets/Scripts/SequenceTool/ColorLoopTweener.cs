using UnityEngine;

public class ColorLoopTweener : SequenceAction
{
	public SpriteRenderer spriteRendererToTween;

	public Color startColor;
	public Color endColor;
	private Color colorOnEnter;
	
	public float loopDuration = 0;
	private float loopTimer = 0;

	private bool isTweening = false;

	private void Update()
	{
		if (!isTweening) { return; }

		UpdateColorOverTime();
		UpdateTimer();
		UpdateLoopTimer();
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

	private void UpdateLoopTimer()
	{
		loopTimer += Time.deltaTime;

		if(loopTimer > loopDuration)
		{
			loopTimer = 0;
		}
	}

	private void UpdateColorOverTime()
	{
		float normalizedTimer = NormalizeTo01Scale(0, loopDuration, loopTimer);
		spriteRendererToTween.color = Color.Lerp(startColor, endColor, normalizedTimer);
	}

	private void ResetColor()
	{
		spriteRendererToTween.color = colorOnEnter;
	}

	public override void StartTween()
	{
		isTweening = true;
		colorOnEnter = spriteRendererToTween.color;
	}

	public override void StopTween()
	{
		isTweening = false;
		tweenTimer = 0;
		loopTimer = 0;
		spriteRendererToTween.color = colorOnEnter;
	}
}
