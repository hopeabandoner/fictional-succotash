using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HitScanWeapon : MonoBehaviour {
    public float currentClip = 15;
    public float allAmmo;
    public float damage;
	public GameObject muzzleFlash;
	public GameObject gunTip;
	[Header("Gun Sounds:")]
	//Gun sounds
	public AudioSource gunSoundSource;
	public AudioClip gunSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //Fire weapon
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        currentClip--;
		Instantiate (muzzleFlash, new Vector3 (gunTip.transform.position.x, gunTip.transform.position.y, gunTip.transform.position.z), gunTip.transform.rotation);
		gunSoundSource.pitch = Random.Range (0.8f,1.1f);
		gunSoundSource.PlayOneShot(gunSound);

		RaycastHit hit;

        //get the forward vector
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //draw the raycast
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            print("Hit something!");

            //check if the raycast hit an enemy
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

                print("hit an enemy");
                //apply damage
            }
        }
    }

    void OnGUI()
    {

        //debug only: display ammo
        GUI.Label(new Rect(10, 10, 128, 32), "Ammo: " + currentClip.ToString());

    }
}
