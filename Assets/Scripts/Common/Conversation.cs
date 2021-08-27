using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Common
{
	public class Conversation : MonoBehaviour
	{
		public DialogueElement firstElement;
		private  TextMeshProUGUI textObj;

		private List<DialogueElement> dialogueElements;
		private DialogueElement currentElement;

		private void Awake()
		{
			textObj = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();

			dialogueElements = new List<DialogueElement>(Resources.LoadAll<DialogueElement>("Data/Dialogue"));
		}

		private void Start()
		{
			currentElement = firstElement;
			textObj.text = firstElement.text;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				if (currentElement != null)
				{
					currentElement = currentElement.nameOfNextDialogue != null ?
						dialogueElements.Find(o => o.name == currentElement.nameOfNextDialogue)
						: null;
				}

				if (currentElement)
				{
					textObj.text = currentElement.text;
				}
				else
				{
					textObj.text = "Ok that's it.";
				}
			}
		}
	}
}