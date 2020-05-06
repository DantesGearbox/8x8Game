using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SequenceTool;

public class Bullet : MonoBehaviour
{
	public float movespeed = 10;
	public Sequence explode;

	private Rigidbody2D rb;

	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * movespeed; //Send the bullet along it's rotation
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Enemy" || collision.tag == "Terrain")
		{
			explode.StartSequence();
		}
	}
}
