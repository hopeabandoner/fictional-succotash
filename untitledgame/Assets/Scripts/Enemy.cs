using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [Header("Vitals")]
    public float health = 100;
    [Header("AI")]
    public GameObject target;
    public float aggroDistance = 5;
    public float attackdistance = 1;
    public float attackSpeed = 1.5f;
    public float attackDamage = 15;
    public float curDistance;
    float lastattack;
    bool canAttack = false;
    public float attackspeed;

    public NavMeshAgent nva;

	public GameObject dustParticles;
    // Use this for initialization
    void Start () {

        nva = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
        if (lastattack > 0)
		{ lastattack -= Time.deltaTime; }

        curDistance = Vector3.Distance(target.transform.position, transform.position);
        canAttack = !(lastattack > 0);

        //kill the enemy when their health is 0
        if (health <= 0)
        {
			Instantiate (dustParticles, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }

        if(curDistance <= aggroDistance)
        {
            AIMove();
        }

		if (curDistance <= attackdistance && canAttack)
        {
            AIAttack();
			canAttack = false;
        }
    }


    //take damage
    public void ApplyDamage(float thedamage)
    {
        health -= thedamage;
    }

    void AIMove()
    {
        nva.destination = target.transform.position;
        
    }


    void AIAttack()
    {
		lastattack = attackSpeed;
        print("attacked");
        target.gameObject.SendMessage("ApplyDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
    }
}
