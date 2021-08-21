using Battle;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	/// <summary>
	/// TODO: Use this instead of BattleController directly for move related things (like damage dealing)
	/// </summary>
	public class MoveEventHandler
	{
		private BattleController controller;
		private MoveBehavior behavior;

		//public UnityEvent
		//	Select, //When the player selects the move
		//	Deselect, //When the player backs out of a move
		//	Use, //When the player activates the move, confirming any choices
		//	Begin, //When the move starts an effect
		//	Stop, //When the move stops an effect
		//	End; //When the move finishes

		public MoveEventHandler(BattleController controller)
		{
			this.controller = controller;
		}

		public void Subscribe(Move subscriber)
		{
			behavior = subscriber.behavior;
			behavior.AttachController(controller);
		}

		public IEnumerator Select()
		{
			return behavior.OnSelect();
		}

		public IEnumerator Use()
		{
			return behavior.OnUse();
		}

		public GUIHelper GUI() => controller.gui;
	}
}