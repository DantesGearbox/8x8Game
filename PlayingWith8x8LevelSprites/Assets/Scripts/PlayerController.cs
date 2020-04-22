using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	float movespeed = 5;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(xInput, yInput).normalized;
		rb.velocity = direction * movespeed;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//dodgeRoll.StopTimer(); //To reset it
			//dodgeRoll.StartTimer(); //To start it up
		}
	}
}
