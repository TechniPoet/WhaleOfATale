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
	PlayerScript p;
	Player player;
	Rigidbody rigid;
	bool settingsSet = false;
	// Use this for initialization
	void Start ()
	{
		player = ReInput.players.GetPlayer(playerID);
		rigid = GetComponent<Rigidbody>();
	}

	public void SetSettings(PlayerScript s)
	{
		p = s;
		settingsSet = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (settingsSet && p.playerSettings.isPlayer)
		{
			rigid.AddForce(transform.forward * (p.playerSettings.moveSpeed * player.GetAxis("leftx")));
			rigid.AddForce(transform.right * (p.playerSettings.moveSpeed * player.GetAxis("lefty")));

			if (rigid.velocity.magnitude > p.playerSettings.maxSpeed)
			{
				rigid.velocity = rigid.velocity.normalized * p.playerSettings.maxSpeed;
			}

			Vector3 rotation = new Vector3(0, player.GetAxis("rightx"), 0);
			transform.Rotate(p.playerSettings.rotateSpeed * rotation);
		}
		
	}
}