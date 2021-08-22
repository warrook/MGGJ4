using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Battle
{
	public abstract class ActionCommand
	{
		/* Needed pieces:
		 * - Begin, to draw all UI elements and wait for input
		 * - Use, that takes input while the action command is going
		 */
		protected MoveEventHandler handler;
		private GUIHelper gui;

		public void AttachHandler(MoveEventHandler handler)
		{
			this.handler = handler;
			gui = handler.GUI();
		}

		public virtual IEnumerator Begin()
		{
			yield return Use();
		}

		public virtual IEnumerator Use()
		{
			gui.Draw();
			yield return null;
		}
	}
}
