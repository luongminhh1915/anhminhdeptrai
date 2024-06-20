using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boii : MonoBehaviour
{
    public float swimSpeed = 2f;
    public float waitTime = 2f;
    public float waitTimeVariation = 1f;

    private Rigidbody2D rb;
    private bool isSwimmingRight = true;
    private float currentWaitTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentWaitTime = waitTime + Random.Range(-waitTimeVariation, waitTimeVariation);
    }

    void Update()
    {
        currentWaitTime -= Time.deltaTime;
        if (currentWaitTime <= 0)
        {
            ChangeDirection();
            currentWaitTime = waitTime + Random.Range(-waitTimeVariation, waitTimeVariation);
        }

        SwimInDirection();
    }

    void ChangeDirection()
    {
        isSwimmingRight = !isSwimmingRight;
    }

    void SwimInDirection()
    {
        float direction = isSwimmingRight ? 1f : -1f;
        rb.velocity = new Vector2(direction * swimSpeed, rb.velocity.y);
    }
}