using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int ammoSpeed;
    public float handSpeedStart, handSpeedEnd;
    public GameObject ammo, spawnPoint, parent, hand;
    private Rigidbody handRb;
    private Vector3 handVelocity;
    private bool shootOn = false;
    private float handSpeed;
    // Start is called before the first frame update
    void Start()
    {
        handRb = hand.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        handVelocity = handRb.velocity;
        handSpeed = handVelocity.magnitude;

        if(shootOn == false && handSpeed >= handSpeedStart)
        {
            shootOn = true;
        }
        if (Input.GetKeyDown(KeyCode.F) || shootOn == true && handSpeed <= handSpeedEnd)
        {
            FireBullet();
            shootOn = false;
        }
    }
    private void FireBullet()
    {
        Quaternion rotation = spawnPoint.transform.rotation;
        GameObject ammoObj = Instantiate(ammo, spawnPoint.transform.position, rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * ammoSpeed, ForceMode.Force);
        ammoObj.transform.SetParent(parent.transform);
    }
}
