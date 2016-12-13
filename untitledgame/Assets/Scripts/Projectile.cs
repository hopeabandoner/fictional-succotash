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

        float realtime = speed * Time.deltaTime;
        if (!target)
        {
            transform.Translate(Vector3.forward * realtime * Time.deltaTime);
        }

        
        if(target)
        {
            transform.position = Vector3.Lerp (transform.position, target.transform.position, realtime * Time.deltaTime);

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
