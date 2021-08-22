using Battle;
using System;
using System.Collections;
using UnityEngine;

namespace Battle
{
	[CreateAssetMenu(menuName = "Game/Move")]
	public class Move : ScriptableObject
	{
		public new string name;
		public string description;
		public float cost;
		[SerializeField] private string moveBehaviorName;

		public MoveBehavior behavior
		{
			get
			{
				if (bhvr == null)
				{
					bhvr = (MoveBehavior)Activator.CreateInstance(Type.GetType("Battle.Moves." + moveBehaviorName));
				}
				return bhvr;
			}
		}
		private MoveBehavior bhvr;


		private static Type GetType(string typeName)
		{
			if (Type.GetType(typeName) != null) return Type.GetType(typeName);
			foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
			{
				if (a.GetType(typeName) != null) return Type.GetType(typeName);
			}
			return null;
		}
	}
}