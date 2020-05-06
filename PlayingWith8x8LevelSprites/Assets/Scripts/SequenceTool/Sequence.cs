using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class Sequence : MonoBehaviour
	{
		public bool finishBeforeNextExecution = true;

		public Action[] actions;

		private float timer = 0;
		private bool sequenceIsExecuting = false;

		private void Start()
		{
			actions = GetComponentsInChildren<Action>();
		}

		private void Update()
		{
			//Start relevant actions
			foreach (Action action in actions)
			{
				if (timer > action.startingTime && !action.isExecuting && !action.hasExecuted)
				{
					action.StartAction();
				}
			}

			//Stop sequence if all actions are done
			if (AreAllActionsDone())
			{
				StopSequence();
			}

			//Update timer
			if (sequenceIsExecuting)
			{
				timer += Time.deltaTime;
			}
		}

		public bool AreAllActionsDone()
		{
			bool areAllActionsDone = true;
			foreach (Action action in actions)
			{
				if (!action.hasExecuted)
				{
					areAllActionsDone = false;
				}
			}
			return areAllActionsDone;
		}

		public bool IsSequenceExecuting()
		{
			return sequenceIsExecuting;
		}

		public void StartSequence()
		{
			if(finishBeforeNextExecution && sequenceIsExecuting) { return; }

			StopAllActions();
			ResetAllActions();
			sequenceIsExecuting = true;
			timer = 0;
		}

		public void StopSequence()
		{
			sequenceIsExecuting = false;
			timer = 0;
			StopAllActions();
		}

		public void StopSequenceImmediately()
		{
			sequenceIsExecuting = false;
			timer = 0;
			StopAllActionsImmediately(); //WARNING: This might make the EndAction function of all actions play twice over a sequence.
		}

		public void PauseSequence()
		{
			sequenceIsExecuting = false;
		}

		private void StopAllActions()
		{
			foreach (Action action in actions)
			{
				action.isExecuting = false;
			}
		}

		private void ResetAllActions()
		{
			foreach (Action action in actions)
			{
				action.hasExecuted = false;
			}
		}

		private void StopAllActionsImmediately()
		{
			foreach (Action action in actions)
			{
				action.EndAction();
			}
		}
	}
}
