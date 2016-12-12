using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float speed;
    public float damage = 50;
    public GameObject target;
	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Enemy"); 

	}
	
	// Update is called once per frame
	void Update () {
        if (!target)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        
        if(target)
        {
            transform.position = Vector3.Slerp(transform.position, target.transform.position, speed * Time.deltaTime);

        }

    }

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
    }


    IEnumerator DecayTime()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
