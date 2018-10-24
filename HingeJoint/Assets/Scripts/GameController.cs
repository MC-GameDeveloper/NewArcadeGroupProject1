using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class GameController : MonoBehaviour {

	private SerialPort stream = new SerialPort("\\\\.\\COM11", 9600);
	private Vector3 temp;
	// Use this for initialization
	void Start () {
		stream.Open();
		stream.ReadTimeout = 25;
		StartCoroutine (readString ());


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator readString() {

		while (true) {

			if (stream.IsOpen) {
				try
				{

					string value = stream.ReadLine();
					string[] values = value.Split(',');
					//Debug.Log(values[0]);
					Debug.Log(float.Parse(values[0]));
					temp = transform.rotation.eulerAngles;
					temp.z = Mathf.Clamp(float.Parse(values[0]),-25,25);
					transform.rotation = Quaternion.Euler(temp);



				}
				catch (System.Exception) {

				}

			}

			yield return null;

		}

	}
}