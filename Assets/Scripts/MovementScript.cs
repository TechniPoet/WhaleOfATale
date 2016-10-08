using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class MovementScript : MonoBehaviour
{
	public int playerID;
	public float moveSpeed;
	Player player;
	Rigidbody rigid;

	// Use this for initialization
	void Start ()
	{
		player = ReInput.players.GetPlayer(playerID);
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigid.AddForce( Vector3.forward * ( moveSpeed * player.GetAxis("vert axis")));
		rigid.AddForce(Vector3.right * (moveSpeed * player.GetAxis("horiz axis")));
	}
}
