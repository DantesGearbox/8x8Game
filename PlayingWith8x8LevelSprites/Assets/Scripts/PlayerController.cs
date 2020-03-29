using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	float movespeed = 5;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(xInput, yInput).normalized;
		rb.velocity = direction * movespeed;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameEvents.instance.OnDodgeButtonPressedEvent();
		}
	}
}
