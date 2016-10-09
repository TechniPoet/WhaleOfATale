using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstFile
{

}

[System.Serializable]
public class GhostSettings
{
	public float moveSpeed = 200f;
	public float seperationDist = 10f;
	public float neighborDist = 5f;
	public float maxSpeed = 30f;
}