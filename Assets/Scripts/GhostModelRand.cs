using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostModelRand : MonoBehaviour {
	public GameObject face1;
	public GameObject face2;


	// Use this for initialization
	void Start ()
	{
		if (Random.Range(0, 1f) > 0.5f)
		{
			face1.SetActive(false);
		}
		else
		{
			face2.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
