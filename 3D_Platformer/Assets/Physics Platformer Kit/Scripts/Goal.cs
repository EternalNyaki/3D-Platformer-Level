﻿using UnityEngine;
using UnityEngine.SceneManagement;

//add this to your "level goal" trigger
[RequireComponent(typeof(CapsuleCollider))]
public class Goal : MonoBehaviour
{
	public float lift;              //the lifting force applied to player when theyre inside the goal
	public float loadDelay;         //how long player must stay inside the goal, before the game moves onto the next level
	public int nextLevelIndex;  //scene index of the next level
	public string nextLevelName;
	public bool importantGoal = false;

	private float counter;

	void Awake()
	{
		GetComponent<Collider>().isTrigger = true;
		if (importantGoal && PlayerPrefs.GetInt(nextLevelName + " Complete") == 1)
		{
			GetComponent<MeshRenderer>().materials[0].color = new Color(184, 255, 184, 117);
			GetComponentInChildren<Light>().color = Color.green;
		}
	}

	//when player is inside trigger for enough time, load next level
	//also lift player upwards, to give the goal a magical sense
	void OnTriggerStay(Collider other)
	{
		Rigidbody rigid = other.GetComponent<Rigidbody>();
		if (rigid)
			rigid.AddForce(Vector3.up * lift, ForceMode.Force);

		if (other.tag == "Player")
		{
			counter += Time.deltaTime;
			if (counter > loadDelay)
			{
				PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + " Complete", 1);
				SceneManager.LoadScene(nextLevelIndex);
			}
		}
	}

	//if player leaves trigger, reset "how long they need to stay inside trigger for level to advance" timer
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			counter = 0f;
	}
}