using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
	public GameObject drop;
	void Update()
	{
		Vector2 spawnPosition = transform.position;     //	We set the spawn position to initially be our (spawner) position
		spawnPosition.x += Random.Range(0f, 10f);   //	Then, add a random amount between 0 and 10 to our X position

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(drop, spawnPosition, Quaternion.identity);  //	Note that we spawn the drop at our Vector2 we called spawnPosition
		}
	}
}
