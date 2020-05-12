using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class MovementOverTime : OverTimeAction
	{
		[Header("A header")]
		public Rigidbody2D rigidbody2DReference;

		//public Vector3Wrapper vector3Reference;

		//public bool useVectorRefAsDirection = false;
		//public bool useReverseVector = false;

		[Tooltip("The movement that will occur over the duration of the action")]
		public Vector2 movement;

		private Vector2 movementVector;

		public override void StartAction()
		{
			base.StartAction();

			//Vector2 moveDirection = direction.normalized;
			//if (useVectorRefAsDirection)
			//{
			//	moveDirection = vector3Reference.vectorValue.normalized;
			//}
			//if (useReverseVector)
			//{
			//	moveDirection = (vector3Reference.vectorValue * -1.0f).normalized;
			//}

			//movementVector = moveDirection * speed;
			//rigidbody2DReference.velocity = movementVector;

			Vector2 movementPerSecond = movement / actionDuration;
			rigidbody2DReference.velocity = movementPerSecond;
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