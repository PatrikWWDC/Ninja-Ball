using UnityEngine;
using appnext;
using System.Collections;

public class AppNextNinjaBall : MonoBehaviour {

	private FullscreenVideo fullscreenVideo;

	public static AppNextNinjaBall instance;

	// Use this for initialization
	void Awake () {
		fullscreenVideo = new FullscreenVideo("cd1fc0cb-6f1c-402f-8dd6-f41c2b59e02b");
		fullscreenVideo.loadAd ();
		instance = this;
		Debug.Log ("AppNext AD Loader loaded!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ad() {
		fullscreenVideo.showAd();
	}
}
