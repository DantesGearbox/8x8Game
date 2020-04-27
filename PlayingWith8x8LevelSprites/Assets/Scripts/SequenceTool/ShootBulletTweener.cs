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
		//Vector3 rot = new Vector3(vector3Reference.vectorValue.x, 0, vector3Reference.vectorValue.y);
		//Instantiate(bullet, transform.position + spawnOffset, Quaternion.LookRotation(rot));
		Instantiate(bullet, transform.position + spawnOffset, Quaternion.identity);
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
