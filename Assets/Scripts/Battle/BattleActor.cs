using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Battle
{
    public class BattleActor : MonoBehaviour
    {
        public ActorData data;

		string characterName;
		float health, power;
        Move[] moveSet;
		bool dead;
		Alignment alignment;

		public string CharacterName => characterName;
		public Move[] MoveSet => moveSet;
		public bool IsAlive => !dead;
		public Alignment Alignment => alignment;

		private void Awake()
		{
			health = data.defaultHealth;
			power = data.defaultPower;
			moveSet = data.moveSet;
		}

		public void Initialize(string name, Alignment alignment)
		{
			characterName = name;
			this.alignment = alignment;
		}

		public IEnumerator PickMove()
		{
			int carat = 0;

			yield return null;
		}
	}
}