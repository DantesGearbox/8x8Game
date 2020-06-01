using UnityEngine;

namespace SequenceTool
{
	public class MovementOverFixedTime : OverFixedTimeAction
	{
		[Header("A header")]
		public Rigidbody2D rigidbody2DReference;
		
		public Vector3Wrapper movementVectorInput;

		public bool useInputAsDirection = false;
		public bool useReverseVector = false;
		
		public Vector2 direction;
		public float distance;
		
		private Vector2 moveDirection;

		private Vector2 onEnterValue;

		private Vector2 startPosition;
		private Vector2 endPosition;

		public override void StartAction()
		{
			base.StartAction();

			moveDirection = direction.normalized;
			if (useInputAsDirection)
			{
				moveDirection = movementVectorInput.vectorValue.normalized;
			}
			if (useReverseVector)
			{
				moveDirection = (movementVectorInput.vectorValue * -1.0f).normalized;
			}

			startPosition = rigidbody2DReference.position;
			endPosition = startPosition + (moveDirection * distance); //This position can't quite be expected since collision with other objects might stop it
		}

		protected override void UpdateValue()
		{
			float timeForwards = Time.deltaTime;

			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			float normalizedTimerForward = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer + timeForwards);

			Vector2 currentPosition = Vector2.Lerp(startPosition, endPosition, normalizedTimer);
			Vector2 nextPosition = Vector2.Lerp(startPosition, endPosition, normalizedTimerForward);

			Vector2 diff = nextPosition - currentPosition;

			rigidbody2DReference.velocity = diff * (1/timeForwards);
		}

		protected override void RestoreOriginalValue()
		{
			rigidbody2DReference.velocity = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			rigidbody2DReference.velocity = Vector2.zero;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = rigidbody2DReference.velocity;
		}
	}
}