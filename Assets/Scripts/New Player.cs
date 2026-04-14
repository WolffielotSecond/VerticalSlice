using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2.5f;
    //The player is inputting inversely
    public bool shouldInvertMovement;
    //The player is walking in a scene that should be inverted, but did release the keys
    public bool shouldBeInvertMovement;
    [Space]
    [Header("References")]
    public GameObject playerObj;
    private Rigidbody rb;
    [SerializeField] private Animator _animator;
    private float verticalInput;
    private float horizontalInput;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //_animator = playerObj.GetComponent<Animator>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        if (shouldInvertMovement)
        {
            verticalInput *= -1;
            horizontalInput *= -1;
        }
        if (verticalInput != 0 || horizontalInput != 0)
        {
            _animator.SetBool("ShouldMove", true);
            //Debug.Log("Player is moving");
        }
        else
        {
            _animator.SetBool("ShouldMove", false);
            //Debug.Log("Player is not moving");
        }
        
        /*
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        playerObj.transform.forward = new Vector3(horizontalInput, 0, verticalInput);
        */
        Vector3 moveDir = new Vector3(horizontalInput, 0f, verticalInput);

        // 防止斜向移动变快
        moveDir = Vector3.ClampMagnitude(moveDir, 1f);
        rb.MovePosition(transform.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        if (moveDir.sqrMagnitude > 0.001f)
        {
            playerObj.transform.forward = moveDir;
        }
    }

    

}
