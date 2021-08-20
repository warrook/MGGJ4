using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MoveBaseSingleEnemy : MoveBehavior
{
	protected override Alignment ValidAlignment()
	{
		return Alignment.Enemy;
	}

	protected override int NumTargets()
	{
		return 1;
	}
}
