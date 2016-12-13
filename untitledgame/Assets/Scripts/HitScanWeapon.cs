using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HitScanWeapon : MonoBehaviour {
    public float damage;
    public float minDamage;
    public float maxDamage;
    public bool canShoot = true;
	public float fireRate = 10;
	public bool fullAuto = false;
    float lastFire;
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
	public float currentClip = 15; //Amount of ammo in the gun right now
	public float maxAmmo = 15; //Max amount of ammo in the gun right now
	public float ammoLeft = 30; //Amount of left over ammo
	public float reloadTime = 3.0f; //Time (in seconds) needed to reload
	public float currentReload = 3.0f; //Current second of reload time
	public bool reloading = false;

    public static HitScanWeapon wp;
	// Use this for initialization
	void Start () {

        wp = this;

    }
	
	// Update is called once per frame
	void Update () {
	
        if(lastFire>0)
		{ lastFire -= Time.deltaTime; }

        canShoot = !(lastFire > 0);
        //Fire weapon
		if(Input.GetButtonDown("Fire1") && !reloading && currentClip>0 && canShoot && !fullAuto)
        {
            Shoot();
        }
		if(Input.GetButton("Fire1") && !reloading && currentClip>0 && canShoot && fullAuto)
		{
			Shoot();
		} 
			

		if ((currentClip <= 0 || Input.GetKeyDown(KeyCode.R)) && ammoLeft>0 && reloading == false)
			{reloading = true;
			ReloadGun ();}

		if (reloading == true) {
			currentReload+=Time.deltaTime;
		}

		if (currentReload >= reloadTime && currentClip < maxAmmo && reloading == true) 
		{
			reloading = false;
			float neededAmmo = maxAmmo-currentClip;
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
        lastFire = fireRate;
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
