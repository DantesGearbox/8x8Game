using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class SpawnPrefabInstant : InstantAction
	{
		public GameObject prefab;
		public Vector3 rotation;
		public Vector3 globalOffset;
		public float offsetLength;

		public Vector3Wrapper offsetDirectionReference;

		public Vector3Wrapper facingDirectionReference;
		public bool useFacingDirectionAsRotation;

		protected override void SetToValue()
		{
			if (useFacingDirectionAsRotation)
			{
				SpawnPrefabWithFacingDirection();
			}
			else
			{
				SpawnPrefab();
			}
		}

		private void SpawnPrefab()
		{
			Vector3 offset = offsetDirectionReference.vectorValue.normalized * offsetLength;
			GameObject obj = Instantiate(prefab, transform.position + offset + globalOffset, Quaternion.Euler(rotation));
		}

		private void SpawnPrefabWithFacingDirection()
		{
			Vector3 dir = facingDirectionReference.vectorValue;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
			Vector3 addedOffsetRot = rot.eulerAngles + new Vector3(0, 0, -90);

			Vector3 offset = offsetDirectionReference.vectorValue.normalized * offsetLength;

			GameObject obj = Instantiate(prefab, transform.position + offset + globalOffset, Quaternion.Euler(addedOffsetRot));
		}

		private void OnDrawGizmos()
		{
			Vector3 offset = offsetDirectionReference.vectorValue.normalized * offsetLength;
			Gizmos.DrawWireSphere(transform.position + offset + globalOffset, 0.25f);
		}
	}
}
