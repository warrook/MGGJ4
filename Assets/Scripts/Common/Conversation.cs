using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Common
{
	public class Conversation : MonoBehaviour
	{
		public DialogueElement element;
		public TextMeshProUGUI textObj;

		private void Awake()
		{
			textObj = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
		}

		private void Start()
		{
			textObj.text = element.text;
		}
	}
}