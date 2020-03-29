using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTweener : MonoBehaviour
{
    void Start()
    {
		GameEvents.instance.OnDodgeButtonPressed += OnDodgeButtonPressed;
	}

	private void OnDodgeButtonPressed()
	{
		Debug.Log("OnDodgeButtonPressedEvent recieved");
	}

	//How to start it: 
	//#1: the player controller has a float tweener field and starts it automatically through code.
}
