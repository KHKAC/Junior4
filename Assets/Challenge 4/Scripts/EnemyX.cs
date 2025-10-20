using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    const float SPEED_START = 1;
    const float SPEED_ADD = 1;
    public float speed;
    private Rigidbody enemyRb;
    GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        speed = SPEED_START;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }
    public void AddSpeed(int wave)
    {
        speed = SPEED_START + SPEED_ADD * wave;
    }

}
