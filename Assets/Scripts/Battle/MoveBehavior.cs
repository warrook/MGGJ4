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

	public IEnumerator TargetSelection()
	{
		if (primaryTarget != TargetSelector.None)
		{
			for (int i = 0; i < numTargets; i++)
			{

			}
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