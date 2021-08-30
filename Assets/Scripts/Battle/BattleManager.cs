using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	public class BattleManager : MonoBehaviour
	{
		private bool isActive;

		public List<BattleActor> allies;
		public List<BattleActor> enemies;
		private List<BattleActor> actors;

		public GUIHelper gui;
		public GameObject markerPrefab;
		private GameObject marker;

		private void Start()
		{
			gui = GameObject.Find("BattleGUI").GetComponent<GUIHelper>();
			StartCoroutine(TurnPacer());
		}

		IEnumerator TurnPacer()
		{
			isActive = true;

			actors = new List<BattleActor>(allies.Count + enemies.Count);
			actors.AddRange(allies);
			actors.AddRange(enemies);

			int round = 0;

			while (true)
			{
				for (var i = 0; i < actors.Count; i++)
				{
					BattleActor actor = actors[i];
					if (actor.Alignment == Alignment.Player)
					{

					}
					else
					{

					}

					//yield return PickMove
					//yield return PickTarget
					//yield return Use
				}
			}
			/*
			while (isActive)
			{
				for (var i = 0; i < parts.Count; i++)
				{
					Character part = parts[i]; //Pick a character to do next
					Move move = part.moveSet[0]; //Take its first move
					Debug.Log(part.name + " " + move.name);
					MoveEventHandler handler = new MoveEventHandler(this); //Make this creation a reference to a singleton instead

					handler.Subscribe(move);

					//yield return move.behavior.TargetSelection(parts.ToArray());
					yield return handler.Select();
					gui.Draw();
					yield return handler.Use();

					yield return WaitForInput();
				}

				round++;
				Debug.Log("Round " + round + " complete");
				yield return WaitForInput();

				if (round > 5)
					break;
			}
			*/
			Debug.Log("Done");
			yield return null;
		}

		IEnumerator WaitForInput()
		{
			while (true)
			{
				if (Input.GetKeyDown(KeyCode.Return))
				{
					break;
				}
				yield return null;
			}

			yield return null;
		}
	}
}