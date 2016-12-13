using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float timeUntilDestroy = 1.0f;
	public float timeLeft;

	void Start() {
		timeLeft = timeUntilDestroy;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			Destroy(this.gameObject);
		}
	}
}
