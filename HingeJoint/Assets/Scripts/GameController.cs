using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class GameController : MonoBehaviour {

	private SerialPort stream1 = new SerialPort("\\\\.\\COM15", 9600);
	private SerialPort stream2 = new SerialPort("\\\\.\\COM17", 9600);
	private Vector3 temp1;
	private Vector3 temp2;

	public GameObject player1;
	public GameObject player2;

	public GameObject targetRef;
	private GameObject targetClone;

	public GameObject ballRef;
	private GameObject ballClone;

	// Use this for initialization
	void Start () {
		stream1.Open();
		stream1.ReadTimeout = 25;
		stream2.Open();
		stream2.ReadTimeout = 25;
		StartCoroutine (readString1 ());
		StartCoroutine (readString2 ());
	}
	
	// Update is called once per frame
	void Update () {
		float randomY = Random.Range (10f, 20f);
		float randomX = Random.Range (-11f, 4.5f);
		Vector3 randomSpawnPos = new Vector3 (randomX, randomY, 0);
		if (targetClone == null) {
			targetClone = Instantiate (targetRef, randomSpawnPos, Quaternion.identity);
		}

		Vector3 ballSpawn = new Vector3 (-2.5f, 6f, 0f);
		if (ballClone == null) {
		
			ballClone = Instantiate (ballRef, ballSpawn, Quaternion.identity);
		}
	}

	//read serial for Player1
	IEnumerator readString1() {

		while (true) {

			if (stream1.IsOpen) {
				try
				{

					string value = stream1.ReadLine();
					Debug.Log(float.Parse(value));
					temp1 = transform.rotation.eulerAngles;
					temp1.z = Mathf.Clamp(float.Parse(value),-20,20);
					player1.transform.rotation = Quaternion.Euler(temp1 * -1);
					Debug.Log("Port1");
			

				}
				catch (System.Exception) {
				}

			}

			yield return null;
		}
	}

	//read serial for Player2
	IEnumerator readString2() {

		while (true) {

			if (stream2.IsOpen) 
			{
				try
				{

					string value = stream1.ReadLine();
					//Debug.Log(values[0]);
					Debug.Log(float.Parse(value));
					temp1 = transform.rotation.eulerAngles;
					temp1.z = Mathf.Clamp(float.Parse(value),-20, 20);
					player2.transform.rotation = Quaternion.Euler(temp1 * -1);
					Debug.Log("Port2");

				}
				catch (System.Exception) {

				}
			}

		yield return null;
		}
	}
}