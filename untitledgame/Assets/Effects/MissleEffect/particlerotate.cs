﻿using UnityEngine;
using System.Collections;

public class particlerotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.left * 100 * Time.deltaTime);


    }
}
