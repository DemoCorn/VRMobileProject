using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Rigidbody rigidBody = null;
    bool Attacking = true;
    private Transform playerPosition;
    private Vector3 startingPosition;

    [SerializeField] private float stopTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        agent.destination = playerPosition.position;

        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.destination == startingPosition)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        agent.destination = playerPosition.position;
                        agent.angularSpeed = 120.0f;
                        Attacking = true;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            agent.destination = startingPosition;
            agent.angularSpeed = 0.0f;
            agent.velocity = startingPosition - gameObject.transform.position / agent.speed;
            rigidBody.angularVelocity = Vector3.zero;
            Attacking = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyStopField" && Attacking)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            Invoke("RestartEnemy", stopTime);
        }
    }

    private void RestartEnemy()
    {
        agent.isStopped = false;
    }
}
