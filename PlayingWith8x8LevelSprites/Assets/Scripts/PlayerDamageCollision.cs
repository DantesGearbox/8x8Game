﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SequenceTool;

public class PlayerDamageCollision : MonoBehaviour
{
	public float playerHealth = int.MaxValue;
	public Sequence getHurt;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Enemy")
		{
			getHurt.StartSequence();

		}
	}
}
