using System.Collections;
using UnityEngine;

public abstract class MoveBehavior
{
	public Character[] targets;

	public TargetSelector primaryTarget => PrimaryTarget();
	public int numTargets => NumTargets();

	protected virtual TargetSelector PrimaryTarget() { return TargetSelector.None; }
	protected virtual int NumTargets() { return 0; }

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

		if (primaryTarget == TargetSelector.None)
		{
			yield return null;
		}
		else
		{
			while (need > 0)
			{
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					carat = ((carat - 1) + participants.Length) % participants.Length;
					Debug.Log(carat);
				}
				if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					carat = (carat + 1) % participants.Length;
					Debug.Log(carat);
				}

				if (Input.GetKeyDown(KeyCode.Space))
				{
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

public enum TargetSelector
{
	None,
	Self,
	Ally,
	Enemy
}