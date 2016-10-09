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
	public int reqGhosts;
}


public class PlayerScript : MonoBehaviour
{
	public MouthScript mouth;
	public MovementScript movement;
	public PlayerSettings playerSettings;
	public GameObject camera;
	public List<GameObject> capturedGhosts = new List<GameObject>();
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
		if (playerSettings.isPlayer)
		{
			if (player.GetButtonDown("RightTrigger") && mouth.onTail && mouth.currTail.GetComponentInParent<PlayerScript>().playerSettings.reqGhosts <= capturedGhosts.Count)
			{
				Debug.Log("bit tail");
				TakeOver();
			}
			if (player.GetButtonDown("RightTrigger") && mouth.ghosts.Count > 0)
			{
				capturedGhosts.AddRange(mouth.ghosts);
				foreach (GameObject g in mouth.ghosts)
				{
					g.GetComponent<GhostScript>().Destroy();
				}
				mouth.ghosts.Clear();
			}
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
