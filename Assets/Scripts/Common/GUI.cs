using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Common
{
	public class GUI : MonoBehaviour
	{
		List<GameObject> uiObjects = new List<GameObject>();

		// Testing --------------------
		public DialogueElement element;
		public Battle.BattleActor actor;

		private void Start()
		{
			//PanelWithText(element.text);
			var l = new List<string>(actor.MoveSet.Length);
			foreach (var move in actor.MoveSet)
			{
				l.Add(move.name);
			}
			//PanelWithText(element.text, "");
			PanelWithText(string.Join("\n", l));
		}
		// ----------------------------

		private GameObject PanelWithText(string text, string name = null)
		{
			var o = Instantiate(GUIPrefabs.PanelWithText);
			var textComp = o.transform.GetComponentInChildren<TextMeshProUGUI>();
			var imageComp = GetImage(o);
			textComp.text = text;

			//Make this width calc actually true instead of easy
			float w = textComp.preferredWidth + 15 * 2;
			w = Mathf.Max(imageComp.sprite.border.x * 2, Mathf.Min(w, Screen.width * 0.9f));
			imageComp.rectTransform.sizeDelta = new Vector2(w, 0); //give it time for preferred height to adjust
			imageComp.rectTransform.sizeDelta = new Vector2(w, textComp.preferredHeight + 15 * 2);

			return o;
		}

		private GameObject PanelWithText(string text)
		{
			var panel = GetImage(Panel());
			Debug.Log(GUIPrefabs.TextElementStretch.GetComponent<TextMeshProUGUI>().rectTransform.offsetMin);
			var textelement = GetText(TextElement("stretch", parent: panel.transform));

			textelement.text = text;
			SizePanelForText(panel, textelement);

			return panel.gameObject;
		}

		private GameObject PanelWithOptions<T>(T[] options, string name = null)
		{
			string[] s = new string[options.Length];
			for (var i = 0; i < options.Length; i++)
			{
				s[i] = options[i].ToString();
			}

			return null; //wip;
		}

		private GameObject Panel(string name = null, Transform parent = null)
		{
			return Instantiate(GUIPrefabs.Panel, name, parent);
		}

		private GameObject TextElement(string element_type, string name = null, Transform parent = null)
		{
			return Instantiate(GUIPrefabs.TextElement(element_type), name, parent);
		}

		//Need to call this again when the window is resized
		private void SizePanelForText(Image panelComponent, TextMeshProUGUI textComponent)
		{
			float maxWidth = Screen.width * 0.9f;
			float maxHeight = Screen.height * 0.5f;

			Vector2 lowerleft = textComponent.rectTransform.offsetMin;
			Vector2 upperright = -textComponent.rectTransform.offsetMax;

			float hzMargin = lowerleft.x + upperright.x;
			float vtMargin = lowerleft.y + upperright.y;
			
			var preferred = textComponent.GetPreferredValues(textComponent.text, maxWidth, maxHeight);
			float x = Mathf.Min(maxWidth, preferred.x);
			float y = Mathf.Min(maxHeight, preferred.y);
			panelComponent.rectTransform.sizeDelta = new Vector2(x + hzMargin, y + vtMargin);
		}

		/// <summary>
		/// Instantiates a prefab with optional name, sets its parent to the GUI object, and adds it to uiObjects
		/// </summary>
		/// <param name="prefab">The prefab to instantiate a copy of.</param>
		/// <param name="name">Optional name of the instance.</param>
		/// <param name="parent">Optional parent of the object</param>
		/// <returns></returns>
		private GameObject Instantiate(GameObject prefab, string name = null, Transform parent = null)
		{
			var o = GameObject.Instantiate(prefab);

			o.transform.SetParent((parent != null ? parent : this.transform), false);
			if (o.transform.parent == this.transform)
				uiObjects.Add(o);
			
			if (name != null)
				o.name = name;
			return o;
		}

		private Image GetImage(GameObject from) => from.GetComponent<Image>();
		private TextMeshProUGUI GetText(GameObject from) => from.GetComponent<TextMeshProUGUI>();


		/// <summary>
		/// Holds all UI Prefabs for convenience
		/// </summary>
		protected static class GUIPrefabs
		{
			static GameObject[] gui_prefabs
			{
				get
				{
					if (prefabs == null)
						prefabs = Resources.LoadAll<GameObject>("UI/Prefabs");
					return prefabs;
				}
			}
			static GameObject[] prefabs;
			public static GameObject Panel => GetPrefab("Panel");
			public static GameObject TextElementStretch => GetPrefab("TextElementStretch");
			public static GameObject PanelWithText => GetPrefab("PanelWithText");

			private static GameObject GetPrefab(string name)
			{
				Debug.Log("Getting GUI prefab " + name);
				return gui_prefabs.First(prefab => prefab.name == name);
			}

			public static GameObject TextElement(string name)
			{
				switch (name)
				{
					case "stretch":
					default:
						return TextElementStretch;
				}
			}
		}
	}
}