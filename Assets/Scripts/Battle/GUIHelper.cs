using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Battle
{
	public class GUIHelper : MonoBehaviour
	{
		public Sprite InactiveSprite, ActiveSprite;
		public Sprite WindowSprite, ProceedSprite;

		//public Canvas canvas;
		private TextMeshProUGUI targetName;

		private void Awake()
		{
			targetName = GameObject.Find("TargetName").GetComponent<TextMeshProUGUI>();
		}

		public IEnumerator OptionWindow(object[] options)
		{


			yield return null;
		}

		public void SetTarget(Character target)
		{
			if (target == null)
			{
				targetName.text = "";
				targetName.gameObject.SetActive(false);
			}
			else
			{
				targetName.gameObject.SetActive(true);
				targetName.transform.position = Camera.main.WorldToScreenPoint(target.gameObject.transform.position) + (Vector3.up * 40);
				targetName.text = target.name + "\n" + target.health + " / " + target.power;

			}
		}

		public void Draw()
		{
			DrawPips(11);
		}

		public void DrawPips(float numPips)
		{
			float width = 20 * (numPips - 1);
			var holder = Window(transform, "PipWindow", 0, width);
			Vector3 centershift = Vector3.right * (width / 2);


			for (int i = 0; i < numPips; i++)
			{
				Vector3 pos = holder.transform.position + (Vector3.right * (20 * i)) - centershift;
				var g = Pip(holder.transform, ActiveSprite, 16, new Color(0.9f, 0.7f, 0.8f));
				g.transform.position = pos;
			}

			holder.transform.position = new Vector3(200, 100);
		}

		private GameObject Pip(Transform parent, Sprite sprite, float size, Color color)
		{
			var g = new GameObject("Pip");
			g.transform.parent = parent;

			var image = g.AddComponent<Image>();
			image.sprite = sprite;
			image.rectTransform.sizeDelta = new Vector2(size, size);
			image.color = color;
			return g;
		}

		private GameObject Window(Transform parent, string name, float internal_height, float internal_width)
		{
			var g = new GameObject(name);
			g.transform.parent = parent;

			var image = g.AddComponent<Image>();
			image.sprite = WindowSprite;
			image.type = Image.Type.Sliced;
			int border = (int)image.sprite.border.x * 2;
			image.rectTransform.sizeDelta = new Vector2(border + internal_width, border + internal_height);

			return g;
		}
	}
}
