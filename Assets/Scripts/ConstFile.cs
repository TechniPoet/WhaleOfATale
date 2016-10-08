using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstFile
{

}

[System.Serializable]
public class GhostSettings
{
	public float moveSpeed = 100f;
	public float seperationDist = 10f;
	public float neighborDist = 14f;
	public float maxSpeed = 10f;
}