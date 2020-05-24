using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class MovementOverTime : OverTimeAction
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
			endPosition = startPosition + moveDirection * distance; //This position can't quite be expected since collision with other objects might stop it



			float speed = distance / actionDuration;
			Vector2 movementVector = moveDirection * speed;
			rigidbody2DReference.velocity = movementVector;
		}

		protected override void UpdateValue()
		{
			//float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			//referencedFloat.floatValue = Mathf.Lerp(startValue, endValue, normalizedTimer);

			//float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			//spriteRendererRef.color = Color.Lerp(startTint, endTint, normalizedTimer);

			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);

			Vector2 currentPosition = rigidbody2DReference.position;




			//rigidbody2DReference.velocity = Vector2.Lerp(startPosition, endPosition, normalizedTimer);
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