using UnityEngine;
using System.Collections;

public class WeaponSway : MonoBehaviour {
    public float moveAmt = 1;
    public float rotAmt = 5;
    public float moveSpd = 2;
    public float rotSpd = 1;
    public GameObject gun;
    public float MoveOnX;
    public float MoveOnZ;
    public float MoveOnY;
    public Vector3 DefaultPos;
    public Vector3 NewPos;
    public Quaternion NewRot;
    public Quaternion DefaultRot;
	// Use this for initialization
	void Start () {

        //TODO: make it less buggy for plebs with bad computers

        DefaultPos = transform.localPosition;
        DefaultRot = transform.localRotation;

    }

    // Update is called once per frame
    void Update () {

		MoveOnX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmt;
		MoveOnY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmt;
        MoveOnZ = Input.GetAxis("Mouse X") * Time.deltaTime * rotAmt;

        NewPos = new Vector3(DefaultPos.x + MoveOnX, DefaultPos.y /*+ MoveOnY*/, DefaultPos.z);

        NewRot = new Quaternion(DefaultRot.x + MoveOnZ, DefaultRot.y + MoveOnZ, DefaultRot.z, DefaultRot.w);

		gun.transform.localPosition = Vector3.Lerp(gun.transform.localPosition, NewPos, moveSpd * Time.deltaTime);
        gun.transform.localRotation = Quaternion.Lerp(DefaultRot, NewRot, rotSpd * Time.deltaTime);

    }
}
