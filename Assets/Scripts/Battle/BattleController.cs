using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject[] allies;
    public GameObject[] enemies;

	private bool active;

	private void Start()
	{
		StartCoroutine(TurnPacer());
	}

	IEnumerator TurnPacer()
	{
		var participants = new List<GameObject>();

		participants.AddRange(allies);
		participants.AddRange(enemies);

		active = true;
		int round = 0;

		while (active)
		{
			for (var i = 0; i < participants.Count; i++)
			{
				Debug.Log(participants[i].name);
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
