using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoundry : MonoBehaviour {

	public const float radius = 10;
	
	public static Vector3 RoundedLocation(Vector3 location)
	{
		if (Vector2.Distance(Vector2.zero, new Vector2(location.x, location.z)) > radius)
		{
			float spawnRadius = radius - .5f;
			float x = Mathf.Clamp(-location.x, -spawnRadius, spawnRadius);
			float z = Mathf.Clamp(-location.z, -spawnRadius, spawnRadius);
			return new Vector3(x, location.y, z);
		}
		return location;
	}
}
