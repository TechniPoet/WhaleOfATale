using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : UnitySingleton<GameGod>
{
	public List<Transform> ghosts = new List<Transform>();

	public GhostSettings ghostSettings = new GhostSettings();
	public delegate void transformDel(Transform t);
	public event transformDel RemoveDeadGhost;
	
	public void AddGhost(Transform t)
	{
		ghosts.Add(t);
	}
}
