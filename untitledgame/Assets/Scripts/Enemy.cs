using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 100;
    public GameObject target;
    public float aggroDistance = 5;
    public float attackdistance = 1;
    public float attackSpeed = 1.5f;
    public float attackDamage = 15;
    float curDistance;
    public NavMeshAgent nva;
    // Use this for initialization
    void Start () {

        nva = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {

       curDistance = Vector3.Distance(target.transform.position, transform.position);

        //kill the enemy when their health is 0
        if (health == 0)
        {
            Destroy(this.gameObject);
        }

        if(curDistance <= aggroDistance)
        {
            AIMove();
        }
	}


    //take damage
    public void ApplyDamage(float thedamage)
    {
        print("took damage");
        health -= thedamage;
    }

    void AIMove()
    {
        nva.destination = target.transform.position;

        if (curDistance >= attackdistance)
        {
            AIAttack();
        }
    }

    void AIAttack()
    {
        nva.Stop();
        target.transform.SendMessage("ApplyDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
        restartAttack();
    }

    IEnumerator restartAttack()
    {
        yield return new WaitForSeconds(attackSpeed);
        AIAttack();
    }
}
