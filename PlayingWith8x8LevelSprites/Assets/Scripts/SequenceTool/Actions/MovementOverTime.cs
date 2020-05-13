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

		public override void StartAction()
		{
			base.StartAction();

			Vector2 moveDirection = direction.normalized;
			if (useInputAsDirection)
			{
				moveDirection = movementVectorInput.vectorValue.normalized;
			}
			if (useReverseVector)
			{
				moveDirection = (movementVectorInput.vectorValue * -1.0f).normalized;
			}

			float speed = distance / actionDuration;
			Vector2 movementVector = moveDirection * speed;
			rigidbody2DReference.velocity = movementVector;
		}

		public override void EndAction()
		{
			base.EndAction();

			rigidbody2DReference.velocity = Vector2.zero;
		}

		protected override void UpdateValue()
		{

		}

		protected override void RestoreOriginalValue()
		{

		}

		protected override void SetToEndValue()
		{
			
		}

		protected override void StoreOriginalValue()
		{
			
		}
	}
}