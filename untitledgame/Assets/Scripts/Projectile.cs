using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float speed;
    public GameObject target;
	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Enemy"); 

	}
	
	// Update is called once per frame
	void Update () {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

	}
}
