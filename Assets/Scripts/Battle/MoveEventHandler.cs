using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MoveEventHandler
{
	public UnityEvent
		Select, //When the player selects the move
		Deselect, //When the player backs out of a move
		Use, //When the player activates the move, confirming any choices
		Begin, //When the move starts an effect
		Stop, //When the move stops an effect
		End; //When the move finishes

	public MoveEventHandler()
	{
		Select = new UnityEvent();
		Deselect = new UnityEvent();
		Use = new UnityEvent();
		Begin = new UnityEvent();
		Stop = new UnityEvent();
		End = new UnityEvent();
	}

	public void Subscribe(Move subscriber)
	{
		MoveBehavior behavior = subscriber.behavior;

		Select.AddListener(behavior.OnSelect);
		Deselect.AddListener(behavior.OnDeselect);
		Use.AddListener(behavior.OnUse);
		Begin.AddListener(behavior.OnBegin);
		Stop.AddListener(behavior.OnStop);
		End.AddListener(behavior.OnEnd);
	}
}