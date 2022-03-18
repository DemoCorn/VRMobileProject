using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public int powerUpCount;
    public GameObject ammo;
    public GameObject powerUpCountDisplayObj;
    private Text powerUpCountDisplay;
    private GameObject[] enemys;

    private void Start()
    {
        powerUpCountDisplay = powerUpCountDisplayObj.GetComponent<Text>();
        powerUpCountDisplay.text = "Power Up Left:" + powerUpCount.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in enemys)
        {
            Instantiate(ammo, item.transform.position, Quaternion.identity);
            powerUpCount--;
            powerUpCountDisplay.text = "Power Up Left:" + powerUpCount.ToString();
        }
        if (powerUpCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
