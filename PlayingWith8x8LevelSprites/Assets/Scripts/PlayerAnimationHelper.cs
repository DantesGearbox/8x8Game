﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SequenceTool;

public class PlayerAnimationHelper : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	SpriteRenderer sr;

	public BoolWrapper animHelperEnabled;
	
    void Start()
    {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
    }
	
    void Update()
    {
		//Set animation parameters
		if (rb.velocity.magnitude > 0)
		{
			anim.SetBool("IsRunning", true);
		}
		else
		{
			anim.SetBool("IsRunning", false);
		}

		if (!animHelperEnabled.boolValue)
		{
			return;
		}

		//Turn the sprite around
		if(rb.velocity.x > 0)
		{
			sr.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}
		if (rb.velocity.x < 0)
		{
			sr.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
		}
	}
}
