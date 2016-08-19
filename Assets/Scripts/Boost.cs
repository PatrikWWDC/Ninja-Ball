using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Ball;

public class Boost : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startBoost() {
		ball.GetComponent<Ball> ().m_MovePower = 3;
	}

	public void stopBoost() {
		ball.GetComponent<Ball> ().m_MovePower = 2;
	}

}
