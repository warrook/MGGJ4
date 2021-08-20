using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MoveMultiHit : MoveBehavior
{
	protected override int NumTargets()
	{
		return 2;
	}

	protected override Alignment ValidAlignment()
	{
		return Alignment.Enemy;
	}
}
