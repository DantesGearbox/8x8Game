using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBulletTweener : Tween
{
	public GameObject bullet;
	public Vector3Wrapper vector3Reference;
	public Vector3 spawnOffset;

	public override void StartTween()
	{
		Vector3 dir = vector3Reference.vectorValue;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
		Vector3 addedOffsetRot = rot.eulerAngles + new Vector3(0, 0, -90);

		GameObject obj = Instantiate(bullet, transform.position + spawnOffset, Quaternion.Euler(addedOffsetRot));
	}

	public override void StopTween()
	{
		
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position + spawnOffset, 0.15f);
	}
}
