using System.Collections;
using UnityEngine;

namespace Battle
{
	public class ActorFactory// : MonoBehaviour
	{
		public GameObject baseActor
		{
			get
			{
				if (cache == null)
					cache = Resources.Load<GameObject>("Bases/ActorBase");
				return cache;
			}
		}
		private GameObject cache;

		public GameObject CreateActor(Common.ActorData actorData, string name = null, Alignment alignment = Alignment.Enemy)
		{ 
			if (name == null)
				name = actorData.actorName;

			GameObject o = GameObject.Instantiate(baseActor);
			BattleActor actor = o.GetComponent<BattleActor>();
			actor.Initialize(name, alignment);
			return o;
		}
	}
}