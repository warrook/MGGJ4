using System.Collections;
using UnityEngine;

public class MoveMagHit : MoveBehavior
{
	public override void OnUse()
	{
		base.OnUse();
		Debug.Log("Do magic");
	}
}