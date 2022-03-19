using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public int powerUpCount;
    public GameObject ammo;
    public int powerUpCd = 10;
    private bool onCd = false;
    public GameObject powerUpCountDisplayObj;
    private Text powerUpCountDisplay;
    private GameObject[] enemys;

    private void Start()
    {
        powerUpCountDisplay = powerUpCountDisplayObj.GetComponent<Text>();
        powerUpCountDisplay.text = "Power Up Left:" + powerUpCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "PlayerProjectile" && onCd == false)
        {
            onCd = true;
            StartCoroutine(tiemr());
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
    private IEnumerator tiemr()
    {
        yield return new WaitForSeconds(powerUpCd);
        onCd = false;
    }
}
