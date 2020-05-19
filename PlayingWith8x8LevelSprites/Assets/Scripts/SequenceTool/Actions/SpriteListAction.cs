using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class SpriteListAction : TimedArbitraryCodeAction
	{
		public SpriteRenderer spriteRendererReference;
		public List<SpriteAndTime> spritesAndTimes;

		protected override void Update()
		{
			if (!isExecuting) { return; }

			SetSpriteBasedOnTime();

			base.Update();
		}

		private void SetSpriteBasedOnTime()
		{
			foreach (SpriteAndTime spriteAndTime in spritesAndTimes)
			{
				if(actionTimer >= spriteAndTime.time)
				{
					spriteRendererReference.sprite = spriteAndTime.sprite;
				}
			}
		}
	}

	[System.Serializable]
	public struct SpriteAndTime
	{
		public Sprite sprite;
		public float time;
	}
}
