using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HitScanWeapon : MonoBehaviour {
    public float currentClip = 15;
    public float allAmmo;
    public float damage;
    public float minDamage;
    public float maxDamage;
    [Header("Effects")]
	public GameObject muzzleFlash;
	public GameObject gunTip;
	[Header("Gun Sounds:")]
	//Gun sounds
	public AudioSource gunSoundSource;
	public AudioClip gunSound;
	// Use this for initialization
	void Start () {

        Mathf.Clamp(currentClip, 0, 30);


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
        //Calculate a random damage
        damage = Random.Range(minDamage, maxDamage);

        currentClip--;
		Instantiate (muzzleFlash, new Vector3 (gunTip.transform.position.x, gunTip.transform.position.y, gunTip.transform.position.z), gunTip.transform.rotation);
		gunSoundSource.pitch = Random.Range (0.8f,1.1f);
		gunSoundSource.PlayOneShot(gunSound);

		RaycastHit hit;

        //Use the camera as the origin point of the ray for aiming purposes
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //get the forward vector
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //draw the raycast
        if (Physics.Raycast(ray, out hit))
        {
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
