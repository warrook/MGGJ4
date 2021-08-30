using System;
using System.Collections;
using UnityEngine;

namespace Battle
{
	public abstract class MoveBehavior
	{
		//protected class CoroutineHandler : MonoBehaviour { }
		//protected static CoroutineHandler coroutineHandler = new GameObject("CoroutineHandler").AddComponent<CoroutineHandler>();

		protected BattleManager controller;
		public Character[] targets;

		// Accessors
		public Alignment alignment => ValidAlignment();
		public Position position => ValidPosition();
		public int numTargets => NumTargets();
		public float damageToDeal => DamageCalc();

		protected virtual Alignment ValidAlignment() { return Alignment.None; }
		protected virtual Position ValidPosition() { return Position.None; }
		protected virtual int NumTargets() { return 0; }
		protected virtual float BaseDamage() { return 0; }
		protected virtual float DamageCalc()
		{
			return BaseDamage();
		}

		public void AttachController(BattleManager controller)
		{
			this.controller = controller;
		}

		// Events --------------- 
		public virtual IEnumerator OnSelect()
		{
			Debug.Log("OnSelect");
			return Select();
		}

		public virtual void OnDeselect() { Debug.Log("OnDeselect"); }

		public virtual IEnumerator OnUse()
		{
			Debug.Log("OnUse");
			return Use();
		}

		public virtual void OnBegin() { Debug.Log("OnBegin"); }

		public virtual void OnStop() { Debug.Log("OnStop"); }

		public virtual void OnEnd() { Debug.Log("OnEnd"); }

		protected virtual IEnumerator Select()
		{
			int need = numTargets;
			Character[] selected = new Character[need];
			Debug.Log("Need " + need + " selected targets.");
			Character[] participants = null;// controller.participants;

			int carat = 0;

			if (numTargets == 0)
			{
				yield return null;
			}
			else
			{
				participants[carat].ShowHideCarat();

				while (need > 0)
				{
					//participants[carat].ShowHideCarat();

					if (Input.GetKeyDown(KeyCode.LeftArrow))
					{
						participants[carat].HideCarat();
						carat = (carat - 1 + participants.Length) % participants.Length;
						participants[carat].ShowCarat();
						Debug.Log(carat);
					}
					if (Input.GetKeyDown(KeyCode.RightArrow))
					{
						participants[carat].HideCarat();

						carat = (carat + 1) % participants.Length;
						participants[carat].ShowCarat();

						Debug.Log(carat);
					}

					if (Input.GetKeyDown(KeyCode.Space))
					{
						participants[carat].HideCarat();

						selected[need - 1] = participants[carat]; //doesn't check if already in list
						need--;
						Debug.Log(carat);
					}

					yield return null;
				}

				Debug.Log("Selected " + selected.Length + " targets");
				targets = selected;
			}

			yield return null;
		}

		protected abstract IEnumerator Use();
	}

	[Flags]
	public enum Alignment : byte
	{
		None = 0,
		Player = 1,
		Ally = 2,
		Enemy = 4
	}

	[Flags]
	public enum Position : byte
	{
		None = 0,
		Ground = 1,
		Air = 2,
		Ceiling = 4
	}
}