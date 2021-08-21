using System.Collections;
using UnityEngine;
using Battle;

public class Character : MonoBehaviour
{
	public new string name;
	public string description;
	public float healthMax;
	public float powerMax;

	public float health { get; private set; }
	public float power { get; private set; }

	public Move[] moveSet;
	private Alignment alignment;
	private Position position;

	//Ugly, get rid of these somehow
	public GameObject markerPrefab;
	private GUIHelper gui;
	private GameObject marker;

	private void Awake()
	{
		gui = GameObject.Find("BattleGUI").GetComponent<GUIHelper>();
		health = healthMax;
		power = powerMax;
	}

	public float Hurt(float by)
	{
		health = health - by < 0 ? 0 : health - by;
		return health;
	}

	public void ShowHideCarat()
	{
		if (CreateCaratIfAbsent().activeInHierarchy)
		{
			HideCarat();
		}
		else
		{
			ShowCarat();
		}
	}

	public void ShowCarat()
	{
		CreateCaratIfAbsent().SetActive(true);
	}

	public void HideCarat()
	{
		CreateCaratIfAbsent().SetActive(false);
	}

	private GameObject CreateCaratIfAbsent()
	{
		if (marker == null)
		{
			marker = Instantiate(markerPrefab, transform.position, markerPrefab.transform.rotation, transform);
		}
		gui.SetTarget(this);
		return marker;
	}
}