using System.Collections;
using UnityEngine;

namespace Battle.Moves
{
	public class MovePhysHit : MoveBaseSingleEnemy
	{
		protected override IEnumerator Use()
		{
			Debug.Log("Do Physical");
			return base.Use();
		}
	}
}