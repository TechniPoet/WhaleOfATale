﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviePlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}
}