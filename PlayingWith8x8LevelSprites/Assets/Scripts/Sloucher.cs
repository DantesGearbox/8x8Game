using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SequenceTool;

public class Sloucher : MonoBehaviour
{
	public Sequence getHurt;
	public Vector3Wrapper bulletDirection;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			Rigidbody2D rb = collision.gameObject.GetComponentInParent<Rigidbody2D>();
			bulletDirection.vectorValue = rb.velocity;
			
			getHurt.StartSequence();
		}
	}
}
