using System.Collections;
using UnityEngine;

public class MovePhysHit : MoveBehavior
{
	protected override TargetSelector PrimaryTarget()
	{
		return TargetSelector.Enemy;
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