using System;
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
			GameObject parent = Instantiate(new GameObject("ACHolder"), transform);
			GameObject node = new GameObject("Node");
			Image image = node.AddComponent<Image>();
			image.sprite = InactiveSprite;
			//node.transform.localScale = new Vector3(16, 16);
			image.rectTransform.sizeDelta = new Vector2(16, 16);
			image.color = Color.red;

			GameObject window = new GameObject("window");
			var e = window.AddComponent<Image>();
			e.sprite = WindowSprite;
			float border = 26;
			e.rectTransform.sizeDelta = new Vector2(border * 2 + 20 * 5, border * 2);
			e.type = Image.Type.Sliced;
			Instantiate(window, parent.transform.position, node.transform.rotation, parent.transform);

			for (var i = 0; i < 5; i++)
			{
				Instantiate(node, parent.transform.position + Vector3.right * (20 * i), node.transform.rotation, parent.transform);
			}

			//Destroy(node);
			//Destroy(parent);
			//Destroy(window);

		}
	}
}
