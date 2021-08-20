using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Move")]
public class Move : ScriptableObject
{
	public new string name;
	public string category;
	[SerializeField] private string moveBehaviorName;
	public MoveBehavior behavior
	{
		get
		{
			if (bhvr == null)
			{
				bhvr = (MoveBehavior)Activator.CreateInstance(Type.GetType(moveBehaviorName));
			}
			return bhvr;
		}
	}
	private MoveBehavior bhvr;
}