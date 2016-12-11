using UnityEngine;
using System.Collections;

public class PlayerVitals : MonoBehaviour {
    public float health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            print("you dead nigga");
        }

	}

    public void ApplyDamage(float damage)
    {
        health -= damage;
    }
}
