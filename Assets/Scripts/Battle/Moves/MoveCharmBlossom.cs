using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MoveCharmBlossom : MoveBaseSingleEnemy
{
	protected override Position ValidPosition()
	{
		return Position.Ground | Position.Air;
	}
}
