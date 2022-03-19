using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class Shoot : MonoBehaviour
{
    public int ammoSpeed;
    public GameObject ammo, spawnPoint, parent;

    void Update()
    {
        IVRInputDevice VRInput = VRDevice.Device.PrimaryInputDevice;

        if (Input.GetKeyDown(KeyCode.F) || VRInput.GetButtonDown(VRButton.One))
        {
            FireBullet();
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
