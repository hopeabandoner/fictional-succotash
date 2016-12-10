using UnityEngine;
using System.Collections;

public class HitScanWeapon : MonoBehaviour {
    public float currentClip = 15;
    public float allAmmo;
    public float damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //Fire weapon
        if(Input.GetButtonDown("Fire1"))
        {
            currentClip--;
            RaycastHit hit;

            //get the forward vector
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            //draw the raycast
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                print("Hit something!");

                //check if the raycast hit an enemy
                if (hit.transform.tag == "Enemy")
                {
                    print("hit an enemy");
                    //apply damage
                    hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
	}

    void OnGUI()
    {

        //debug only: display ammo
        GUI.Label(new Rect(10, 10, 128, 32), "Ammo: " + currentClip.ToString());

    }
}
