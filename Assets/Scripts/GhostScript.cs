using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

	Rigidbody rigid;
	GameGod god;
	// Use this for initialization
	void Start ()
	{
		GameGod.Instance.AddGhost(this.transform);
		rigid = GetComponent<Rigidbody>();
		god = GameGod.Instance;
		StartCoroutine(DoThings());
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	IEnumerator DoThings()
	{
		while (true)
		{
			rigid.AddForce(Seperate());
			rigid.AddForce(Cohesion());
			yield return new WaitForSeconds(UnityEngine.Random.Range(0, 1f));
		}
		
	}


	Vector3 Seperate()
	{
		try
		{
			Vector3 sum = Vector3.zero;
			int cnt = 0;

			foreach (Transform t in GameGod.Instance.ghosts)
			{
				float d = Vector3.Distance(transform.position, t.position);

				if (d > 0 && d < GameGod.Instance.ghostSettings.seperationDist)
				{
					Vector3 diff = transform.position - t.position;
					diff.Normalize();
					diff /= d;
					sum += diff;
					cnt++;
				}
			}

			if (cnt > 0)
			{
				sum = sum / cnt;
				sum *= GameGod.Instance.ghostSettings.moveSpeed;
			}
			return sum;
		}
		catch (Exception e)
		{
			Debug.LogError(e);
		}
		return Vector3.one;
	}

	Vector3 Steer()
	{
		return Vector3.one;
	}

	Vector3 Cohesion()
	{
		try
		{
			Vector3 sum = Vector3.zero;
			int cnt = 0;
			foreach (Transform t in GameGod.Instance.ghosts)
			{
				float d = Vector3.Distance(transform.position, t.position);

				if (d > 0 && d < GameGod.Instance.ghostSettings.neighborDist)
				{
					sum += t.position;
					cnt++;
				}
			}
			if (cnt > 0)
			{
				sum /= cnt;
				return Seek(sum);
			}
		}
		catch (Exception e)
		{
			Debug.LogError(e);
		}
		return Vector3.zero;
	}

	Vector3 Seek(Vector3 v)
	{
		Vector3 desired = v - transform.position;
		desired.Normalize();
		desired *= GameGod.Instance.ghostSettings.maxSpeed;
		Vector3 steer = desired - rigid.velocity;
		return steer;
	}
}
