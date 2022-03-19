using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHP;
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            PlayerHP--;
            Destroy(other);
        }
        if(PlayerHP <= 0)
        {
            timer.endGame(false);
        }
    }
}
