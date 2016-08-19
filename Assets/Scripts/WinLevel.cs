using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {
	
	void OnCollisionEnter (Collision col) {
		Debug.Log("Win!");
		AppNextNinjaBall.instance.ad ();
	}
	
}
