using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {
    public float strength = 15;
    public float rotationSpeed = 10;
    public AudioSource soundSource;
    public AudioClip pickupsound;
    // Use this for initialization
    void Start () {

        soundSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        //rotate the object slowly, just for memes
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

	}

    void OnTriggerEnter()
    {
        HitScanWeapon.wp.ammoLeft += strength;
        soundSource.PlayOneShot(pickupsound);
        Destroy(this.gameObject);
    }
}
