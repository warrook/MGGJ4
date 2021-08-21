using Battle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle.Moves
{
	public class MoveBaseSingleEnemy : MoveBehavior
	{
		protected override Alignment ValidAlignment() => Alignment.Enemy;
		protected override int NumTargets() => 1;
		protected override float BaseDamage() => 1;

		protected override IEnumerator Use()
		{
			UnityEngine.Debug.Log("Dealing " + damageToDeal + " damage to " + targets.Length + " target(s)");

			foreach (var t in targets)
			{
				t.Hurt(damageToDeal);
			}
			yield return null;
		}
	}
}