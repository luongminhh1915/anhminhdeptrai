using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caboi2 : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public Animator anim;

    float horizontal;
    float currentSpeed;
    float normalSpeed = 1f;
    float sprintSpeed = 2f;

    bool movingRight = true;
    float switchDirectionTimer = 3f;
    float switchDirectionTimeLeft;
    int moveDirection = 1; // 1 = right, -1 = left

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentSpeed = normalSpeed;
        switchDirectionTimeLeft = switchDirectionTimer;
    }

    void Update()
    {
        horizontal = moveDirection;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }

        switchDirectionTimeLeft -= Time.deltaTime;
        if (switchDirectionTimeLeft <= 0)
        {
            moveDirection *= -1;
            switchDirectionTimeLeft = switchDirectionTimer;
        }

        anim.SetFloat("DiChuyen", Mathf.Abs(horizontal));
        anim.SetFloat("DiChuyenDoc", 0);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + currentSpeed * horizontal * Time.deltaTime;
        position.y = position.y;

        Vector2 movement = new Vector2(horizontal, 0);
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        position += movement * currentSpeed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        if (horizontal > 0 && transform.localScale.x < 0)
        {
            Flip();
        }
        else if (horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        currentScale.y = currentScale.y;
        transform.localScale = currentScale;
    }
}