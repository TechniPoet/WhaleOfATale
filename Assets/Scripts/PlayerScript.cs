using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[System.Serializable]
public class PlayerSettings
{
	public int playerID;
	public float moveSpeed;
	public float maxSpeed;
	public float rotateSpeed;
	public bool isPlayer;
}


public class PlayerScript : MonoBehaviour
{
	public MouthScript mouth;
	public MovementScript movement;
	public PlayerSettings playerSettings;
	public GameObject camera;
	Player player;
	// Use this for initialization
	void Start ()
	{
		movement.SetSettings(this);
		player = ReInput.players.GetPlayer(playerSettings.playerID);
		camera.SetActive(playerSettings.isPlayer);
	}
	

	void Update()
	{
		if (player.GetButtonDown("RightTrigger") && mouth.onTail)
		{
			Debug.Log("bit tail");
			TakeOver();
		}
	}

	void TakeOver()
	{
		mouth.currTail.GetComponentInParent<PlayerScript>().playerSettings.isPlayer = true;
		mouth.currTail.GetComponentInParent<PlayerScript>().camera.SetActive(true);
		playerSettings.isPlayer = false;
		camera.SetActive(false);
	}
	
}
