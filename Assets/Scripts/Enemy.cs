using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody enemyRb;
    GameObject player;
    bool isCatched;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position
        - transform.position).normalized;
        if (!isCatched)
        {
            enemyRb.AddForce(lookDirection * speed);
        }
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MINE"))
        {
            enemyRb.Sleep();
            isCatched = true;
            other.GetComponent<Mine>().AddCatch();
        }
    }
}
