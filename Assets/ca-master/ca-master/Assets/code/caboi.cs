using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caboi : MonoBehaviour
{
    public float swimSpeed = 2f;
    public float turnSpeed = 90f;
    public float minX = -5f, maxX = 5f;
    public float minY = -3f, maxY = 3f;
    public float waitTime = 2f;

    private Vector3 targetPosition;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    private void Start()
    {
        // Đặt vị trí ban đầu của cá
        transform.position = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            transform.position.z
        );

        // Khởi tạo vị trí mục tiêu ban đầu
        SetNewTargetPosition();
    }

    private void Update()
    {
        // Nếu cá đang chờ, giảm đếm thời gian chờ
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                SetNewTargetPosition();
            }
            return;
        }

        // Di chuyển cá về phía mục tiêu
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, swimSpeed * Time.deltaTime);

        // Xoay cá dựa trên hướng di chuyển
        float angle = Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), turnSpeed * Time.deltaTime);

        // Nếu cá đến đích, đặt một mục tiêu mới
        if (transform.position == targetPosition)
        {
            isWaiting = true;
            waitTimer = waitTime;
        }
    }

    private void SetNewTargetPosition()
    {
        // Chọn một vị trí mục tiêu mới trong phạm vi của scene
        targetPosition = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            transform.position.z
        );
    }
}