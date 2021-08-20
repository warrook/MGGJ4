using System;
using System.Collections;
using UnityEngine;

public abstract class MoveBehavior
{
	public Character[] targets;

	public Alignment alignment => ValidAlignment();
	public Position position => ValidPosition();
	public int numTargets => NumTargets();

	protected virtual Alignment ValidAlignment() { return Alignment.None; }
	protected virtual Position ValidPosition() { return Position.None; }
	protected virtual int NumTargets() { return 0; }

	// Events ---------------
	public virtual void OnSelect() { Debug.Log("OnSelect"); } //do logic + coroutine for selecting targets
	public virtual void OnDeselect() { Debug.Log("OnDeselect"); }
	public virtual void OnUse() { Debug.Log("OnUse"); }
	public virtual void OnBegin() { Debug.Log("OnBegin"); }
	public virtual void OnStop() { Debug.Log("OnStop"); }
	public virtual void OnEnd() { Debug.Log("OnEnd"); }

	public IEnumerator TargetSelection(Character[] participants)
	{
		int need = numTargets;
		Character[] selected = new Character[need];
		Debug.Log("Need " + need + " selected targets.");

		int carat = 0;

		if (numTargets == 0)
		{
			yield return null;
		}
		else
		{
			participants[carat].ShowHideCarat();

			while (need > 0)
			{
				//participants[carat].ShowHideCarat();

				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					participants[carat].HideCarat();
					carat = ((carat - 1) + participants.Length) % participants.Length;
					participants[carat].ShowCarat();
					Debug.Log(carat);
				}
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					participants[carat].HideCarat();

					carat = (carat + 1) % participants.Length;
					participants[carat].ShowCarat();

					Debug.Log(carat);
				}

				if (Input.GetKeyDown(KeyCode.Space))
				{
					participants[carat].HideCarat();

					selected[need - 1] = participants[carat]; //doesn't check if already in list
					need--;
					Debug.Log(carat);
				}

				yield return null;
			}

			Debug.Log("Selected " + selected.Length + " targets");
			targets = selected;
		}

		yield return null;
	}
}

[Flags]
public enum Alignment : byte
{
	None = 0,
	Player = 1,
	Ally = 2,
	Enemy = 4
}

[Flags]
public enum Position : byte
{
	None = 0,
	Ground = 1,
	Air = 2,
	Ceiling = 4
}