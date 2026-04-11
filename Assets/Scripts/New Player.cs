using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2.5f;
    public float backwardSpeedMultiplier = 0.7f;
    public float turnSpeed = 120f;

    private float verticalInput;
    private float horizontalInput;

    void Update()
    {
        ReadInput();
        HandleRotation();
        HandleMovement();
    }

    private void ReadInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");     // W/S
        horizontalInput = Input.GetAxisRaw("Horizontal"); // A/D
    }

    private void HandleRotation()
    {
        // A/D：原地转向
        float yaw = horizontalInput * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, yaw, 0f);
    }

    private void HandleMovement()
    {
        // W/S：沿角色当前朝向前后移动
        float currentSpeed = moveSpeed;

        // 后退可以稍微慢一点，更像老生化
        if (verticalInput < 0f)
        {
            currentSpeed *= backwardSpeedMultiplier;
        }

        Vector3 move = transform.forward * verticalInput * currentSpeed * Time.deltaTime;
        transform.position += move;
    }
}
