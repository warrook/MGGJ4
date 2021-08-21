using System.Collections;
using UnityEngine;

namespace Battle.Moves
{
	public class MoveMagHit : MoveBaseSingleEnemy
	{
		protected override IEnumerator Use()
		{
			Debug.Log("Do magic");
			return base.Use();
		}
	}
}