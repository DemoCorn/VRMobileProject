using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Ground" || other.gameObject.tag == "PowerUpBlock")
        {
            Destroy(gameObject);
        }
    }
}
