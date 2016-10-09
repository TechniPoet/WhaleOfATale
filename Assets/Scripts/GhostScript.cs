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
		rigid.AddForce(UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100));
		StartCoroutine(DoThings());
	}

	// Update is called once per frame
	void Update ()
	{
		//transform.position = CircleBoundry.RoundedLocation(transform.position);
		rigid.position = CircleBoundry.RoundedLocation(rigid.position);

		if (rigid.velocity.magnitude > god.ghostSettings.maxSpeed)
		{
			rigid.velocity = rigid.velocity.normalized * god.ghostSettings.maxSpeed;
		}
	}

	IEnumerator DoThings()
	{
		while (true)
		{
			/*
			rigid.AddForce(Seperate());
			rigid.AddForce(Align());
			rigid.AddForce(Cohesion());
			*/
			Swarm();
			yield return new WaitForSeconds(UnityEngine.Random.Range(0, 1.5f));
		}
	}

	void Swarm()
	{
		try
		{
			Vector3 seperateSum = Vector3.zero;
			int seperateCnt = 0;
			Vector3 alignSum = Vector3.zero;
			int alignCnt = 0;
			Vector3 cohesionSum = Vector3.zero;
			int cohesionCnt = 0;

			for (int i=0; i < god.ghosts.Count; i++)
			{
				Transform t = god.ghosts[i];
				float d = Vector3.Distance(transform.position, t.position);

				if (d > 0 && d < GameGod.Instance.ghostSettings.seperationDist)
				{
					Vector3 diff = transform.position - t.position;
					diff.Normalize();
					diff /= d;
					seperateSum += diff;
					seperateCnt++;
				}
				if (d > 0 && d < GameGod.Instance.ghostSettings.neighborDist)
				{
					alignSum += t.GetComponent<Rigidbody>().velocity;
					alignCnt++;
					cohesionSum += t.position;
					cohesionCnt++;
				}
			}

			if (seperateCnt > 0)
			{
				seperateSum = seperateSum / seperateCnt;
				seperateSum *= GameGod.Instance.ghostSettings.moveSpeed;
			}
			if (alignCnt > 0)
			{
				alignSum /= alignCnt;
				alignSum.Normalize();
				alignSum *= god.ghostSettings.maxSpeed;
				Vector3 steer = alignSum - rigid.velocity;
				alignSum = Seek(alignSum);
			}
			if (cohesionCnt > 0)
			{
				cohesionSum /= cohesionCnt;
				cohesionSum = Seek(cohesionSum);
			}

			rigid.AddForce(seperateSum);
			rigid.AddForce(alignSum);
			rigid.AddForce(cohesionSum);
		}
		catch (Exception e)
		{
			Debug.LogError(e);
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

	Vector3 Align()
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
					sum += t.GetComponent<Rigidbody>().velocity;
					cnt++;
				}
			}
			if (cnt > 0)
			{
				sum /= cnt;
				sum.Normalize();
				sum *= god.ghostSettings.maxSpeed;
				Vector3 steer = sum - rigid.velocity;
				return Seek(sum);
			}
		}
		catch (Exception e)
		{
			Debug.LogError(e);
		}
		return Vector3.zero;
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
