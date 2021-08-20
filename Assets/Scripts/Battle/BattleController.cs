using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleController : MonoBehaviour
{
    public Character[] allies;
    public Character[] enemies;

	private List<Character> participants;

	//UnityEvent Select, Use, Begin, Stop, End;

	private bool active;

	private void Start()
	{
		StartCoroutine(TurnPacer());
	}

	IEnumerator TurnPacer()
	{
		participants = new List<Character>();

		participants.AddRange(allies);
		participants.AddRange(enemies);

		active = true;
		int round = 0;

		while (active)
		{
			for (var i = 0; i < participants.Count; i++)
			{
				Character part = participants[i]; //Pick a character to do next
				Move move = part.moveSet[0]; //Take its first move
				Debug.Log(part.name + " " + move.name);
				MoveEventHandler handler = new MoveEventHandler(this); //Make this a reference to a singleton instead

				handler.Subscribe(move);

				yield return move.behavior.TargetSelection(participants.ToArray());
				handler.Select.Invoke();
				handler.Use.Invoke();
				handler.Begin.Invoke();
				handler.Stop.Invoke();
				handler.End.Invoke();

				//Character part = participants[i];
				//Debug.Log(part.name + " " + part.moveSet[0].name);
				//MoveEventHandler handler = new MoveEventHandler();
				//handler.Subscribe(part.moveSet[0]);

				//Debug.Log(part.moveSet[0].behavior.numTargets);

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
