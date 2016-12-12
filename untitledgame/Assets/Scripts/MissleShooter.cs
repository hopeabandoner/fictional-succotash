using UnityEngine;
using System.Collections;

public class MissleShooter : MonoBehaviour {
    public GameObject projectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2"))
        {

          Instantiate(projectile, transform.position, transform.rotation);
        }

	}
}
