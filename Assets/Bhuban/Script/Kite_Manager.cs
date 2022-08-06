using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kite_Manager : MonoBehaviour
{
	public List<GameObject> kites;
	public float rateOfSpawn;
	public float spawnPos;

	float nextSpawn;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		SpawnKite();
	}

	GameObject GetRandom()
	{
		int i = Random.Range(0, kites.Count - 1);
		return kites[i];
	}

	bool isLeft()
	{
		int value = Random.Range(1, 100);
		if (value % 2 != 0)
			return true;
		else
			return false;
	}

	void SpawnKite()
	{
		//bool left = isLeft();
		if (Time.time > nextSpawn)
		{
			nextSpawn = Time.time + rateOfSpawn;
			if (isLeft())
			{
				GameObject clone = Instantiate(GetRandom(), new Vector3(-15, Random.Range(0, 3.5f), 0), Quaternion.identity) as GameObject;
			}
			else
			{
				GameObject clone = Instantiate(GetRandom(), new Vector3(15, Random.Range(0, 3.5f), 0), Quaternion.identity) as GameObject;
			}
		}
	}
}
