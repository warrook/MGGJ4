using Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle.Moves
{
	public class MoveHeartCharmBlossom : MoveBaseSingleEnemy
	{
		protected override Position ValidPosition() => Position.Ground | Position.Air;
	}
}