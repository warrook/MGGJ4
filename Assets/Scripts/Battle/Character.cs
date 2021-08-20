using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
	public Move[] moveSet;
	public Alignment alignment;
	public Position position;

	public GameObject markerPrefab;
	private GameObject marker;

	private void Awake()
	{
		//markerPrefab = Resources.Load<GameObject>("Prefabs/Marker");
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
		return marker;
	}
}