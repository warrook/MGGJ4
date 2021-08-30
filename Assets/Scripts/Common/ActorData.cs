using System.Collections;
using UnityEngine;
using Battle;

namespace Common
{
	[CreateAssetMenu(menuName = "Game/Actor")]
	public class ActorData : ScriptableObject
	{
		//reference to all actor art
		public string actorName;
		public DialogueElement tattleStartDialogue;
		public float defaultHealth;
		public float defaultPower;
		public Move[] moveSet;
	}
}