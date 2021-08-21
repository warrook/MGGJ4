using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace Battle
{
	public class GUIHelper : MonoBehaviour
	{
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
	}
}
