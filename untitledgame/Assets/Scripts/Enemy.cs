using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //kill the enemy when their health is 0
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
	}


    //take damage
    void ApplyDamage(float thedamage)
    {
        health -= thedamage;
    }
}
