using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class MovementScript : MonoBehaviour
{
	public int playerID;
	public float moveSpeed;
	public float maxSpeed;

	public float rotateSpeed;

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
		rigid.AddForce(transform.forward * ( moveSpeed * player.GetAxis("leftx")));
		rigid.AddForce(transform.right * (moveSpeed * player.GetAxis("lefty")));

		if (rigid.velocity.magnitude > maxSpeed)
		{
			rigid.velocity = rigid.velocity.normalized* maxSpeed;
		}

		Vector3 rotation = new Vector3(0, player.GetAxis("rightx"), 0 );
		transform.Rotate(rotateSpeed * rotation);
	}
}
