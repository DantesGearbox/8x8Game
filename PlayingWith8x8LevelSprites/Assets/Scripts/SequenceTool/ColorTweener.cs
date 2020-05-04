using UnityEngine;

public class ColorTweener : SequenceAction
{
	public SpriteRenderer spriteRendererToTween;

	public Color startColor;
	public Color endColor;

	private bool isTweening = false;

	private void Update()
	{
		if (!isTweening) { return; }

	
		UpdateColor();
		UpdateTimer();
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

	private void UpdateColor()
	{
		float normalizedTimer = NormalizeTo01Scale(0, tweenDuration, tweenTimer);
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
	}
}
