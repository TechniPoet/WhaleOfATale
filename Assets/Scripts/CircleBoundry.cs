using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoundry : MonoBehaviour {

	public const float radius = 100;
	public const float height = 100;
	
	public static Vector3 RoundedLocation(Vector3 location)
	{
		if (Vector2.Distance(Vector2.zero, new Vector2(location.x, location.z)) > radius)
		{
			float x = Mathf.Clamp(location.x, -radius, radius);
			float z = Mathf.Clamp(location.z, -radius, radius);

			x = x < 0 ? x + 2 : x - 2;
			z = z < 0 ? z + 2 : z - 2;
			float y = location.y > 100 ? 3 : location.y;
			return new Vector3(-x, y, -z);
		}
		return location;
	}
}
