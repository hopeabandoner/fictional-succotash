using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HitScanWeapon : MonoBehaviour {
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
	public AudioClip startReloadSound;
	public AudioClip endReloadSound;

	[Header("Ammo and Reload:")]
	public int currentClip = 15; //Amount of ammo in the gun right now
	public int maxAmmo = 15; //Max amount of ammo in the gun right now
	public int ammoLeft = 30; //Amount of left over ammo
	public float reloadTime = 180.0f; //Time (in frames) needed to reload
	public float currentReload = 1000.0f; //Current frame of reload time
	public bool reloading = false;
	// Use this for initialization
	void Start () {



    }
	
	// Update is called once per frame
	void Update () {
	
        //Fire weapon
		if(Input.GetButtonDown("Fire1") && !reloading && currentClip>0)
        {
            Shoot();
        }
			

		if ((currentClip <= 0 || Input.GetKeyDown(KeyCode.R)) && ammoLeft>0 && reloading == false)
			{reloading = true;
			ReloadGun ();}

		if (reloading == true) {
			currentReload++;
		}

		if (currentReload >= reloadTime && currentClip < maxAmmo && reloading == true) 
		{
			reloading = false;
			int neededAmmo = maxAmmo-currentClip;
			if (ammoLeft < neededAmmo) 
			{
				neededAmmo = ammoLeft;
			}
			ammoLeft -= neededAmmo;
			currentClip += neededAmmo;
			gunSoundSource.PlayOneShot(endReloadSound);
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
		GUI.Label(new Rect(10, 10, 128, 32), "Ammo: " + currentClip.ToString() + "/" +ammoLeft.ToString());

    }
	void ReloadGun()
	{	
		currentReload = 0;
		gunSoundSource.PlayOneShot(startReloadSound);
	}
}
