using UnityEngine;
using System.Collections;

public class MuzzleFlashScript : MonoBehaviour {

	[Header("Time (in frames) before deletion:")]
	public int timeAlive = 5;
	public int currentTime = 0;

	void Start()
	{
		float randRot = Random.Range (0.0f, 360.0f);
		transform.Rotate (0,0,randRot);

	}
	// Update is called once per frame
	void Update () {
		currentTime += 1;
		if (currentTime >= timeAlive) {
			GameObject.DestroyImmediate (this.gameObject);
		}
	}
}
