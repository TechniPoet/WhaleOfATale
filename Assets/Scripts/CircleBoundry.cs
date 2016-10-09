using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoundry : MonoBehaviour {

	public const float radius = 180;
	public const float height = 30;
	
	public static Vector3 RoundedLocation(Vector3 location)
	{
		if (Vector2.Distance(Vector2.zero, new Vector2(location.x, location.z)) > radius)
		{
			float x = Mathf.Clamp(location.x, -radius, radius);
			float z = Mathf.Clamp(location.z, -radius, radius);

			x = x < 0 ? x + 2 : x - 2;
			z = z < 0 ? z + 2 : z - 2;
			float y = location.y > height ? 3 : location.y;
			return new Vector3(-x, y, -z);
		}
		return location;
	}
}
