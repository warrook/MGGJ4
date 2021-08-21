using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	public class BattleController : MonoBehaviour
	{
		public Character[] allies;
		public Character[] enemies;
		public GameObject markerPrefab;

		public Character[] participants => parts.ToArray();
		private List<Character> parts;
		private GameObject marker;

		public GUIHelper gui;

		//UnityEvent Select, Use, Begin, Stop, End;

		private bool active;

		private void Start()
		{
			gui = GameObject.Find("BattleGUI").GetComponent<GUIHelper>();
			StartCoroutine(TurnPacer());
		}

		IEnumerator TurnPacer()
		{
			parts = new List<Character>();

			parts.AddRange(allies);
			parts.AddRange(enemies); //Desired: add a suffix for identically named enemies

			active = true;
			int round = 0;

			while (active)
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
					yield return handler.Use();

					yield return WaitForInput();
				}

				round++;
				Debug.Log("Round " + round + " complete");
				yield return WaitForInput();

				if (round > 5)
					break;
			}

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