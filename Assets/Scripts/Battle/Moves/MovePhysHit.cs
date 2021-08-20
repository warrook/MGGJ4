using System.Collections;
using UnityEngine;

public class MovePhysHit : MoveBehavior
{
	protected override Alignment ValidAlignment()
	{
		return Alignment.Enemy;
	}

	protected override int NumTargets()
	{
		return 1;
	}

	public override void OnUse()
	{
		base.OnUse();
		Debug.Log("Do physical");
	}
}