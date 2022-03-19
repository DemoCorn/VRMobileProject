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
        print(handSpeed);

        if(shootOn == false && handSpeed >= handSpeedStart ||
            Input.GetButtonUp("Oculus_GearVR_LIndexTrigger") || Input.GetButtonUp("Oculus_GearVR_RIndexTrigger") ||
            Input.GetButtonUp("Oculus_CrossPlatform_PrimaryHandTrigger") || Input.GetButtonUp("Oculus_CrossPlatform_SecondaryHandTrigger"))
        {
            shootOn = true;
        }
        if (Input.GetKeyDown(KeyCode.F) || shootOn == true && handSpeed <= handSpeedEnd ||
            Input.GetButtonDown("Oculus_GearVR_LIndexTrigger") || Input.GetButtonDown("Oculus_GearVR_RIndexTrigger") ||
            Input.GetButtonDown("Oculus_CrossPlatform_PrimaryHandTrigger") || Input.GetButtonDown("Oculus_CrossPlatform_SecondaryHandTrigger"))
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
