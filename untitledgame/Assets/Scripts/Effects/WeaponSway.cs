using UnityEngine;
using System.Collections;

public class WeaponSway : MonoBehaviour {
    public float moveAmt = 1;
    public float moveSpd = 2;
    public GameObject gun;
    public float MoveOnX;
    public float MoveOnY;
    public Vector3 DefaultPos;
    public Vector3 NewPos;
	// Use this for initialization
	void Start () {

        DefaultPos = transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {

        MoveOnX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmt;
        MoveOnY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmt;

        NewPos = new Vector3(DefaultPos.x + MoveOnX, DefaultPos.y + MoveOnY, DefaultPos.z);

        gun.transform.localPosition = Vector3.Lerp(gun.transform.localPosition, NewPos, moveSpd * Time.deltaTime);
    }
}
