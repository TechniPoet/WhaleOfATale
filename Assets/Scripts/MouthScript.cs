using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthScript : MonoBehaviour {

	public bool onTail = false;
	public GameObject currTail;
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log("collided");
		if (c.gameObject.tag == "Tail")
		{
			onTail = true;
			currTail = c.gameObject;
		}
	}

	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "Tail")
		{
			onTail = false;
			currTail = null;
		}
	}
}
