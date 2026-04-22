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
    public float noise = 0f;
    [Space]
    [Header("References")]
    public GameObject playerObj;
    private Rigidbody rb;
    [SerializeField] private Animator _animator;
    private float verticalInput;
    private float horizontalInput;

    private bool parrywindow = false;
    private float parryTimer = 0f;
    private bool isParrying = false;
    private float kickTimer = 0f;
    private bool isKicking = false;
    public bool canKick = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //_animator = playerObj.GetComponent<Animator>();
    }

    void Update()
    {
        if (parryTimer < 3f)
        {
            parryTimer += Time.deltaTime;
        }
        if (parryTimer >= 0.5f)
        {
            parrywindow = false;
        }
        if (parryTimer >= 1.25f)
        {
            isParrying = false;
        }
        if (kickTimer < 2f)
        {
            kickTimer += Time.deltaTime;
        }
        if (kickTimer >= 1.667f)
        {
            isKicking = false;
        }
        if (isKicking)
        {
            _animator.applyRootMotion = true;
        }
        else
        {
            _animator.applyRootMotion = false;
        }

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //if didn't receive input of wsad, set shouldInvertMovement to shouldBeInvertMovement
        if (verticalInput == 0 && horizontalInput == 0)
        {
            shouldInvertMovement = shouldBeInvertMovement;
        }

        if (shouldInvertMovement)
        {
            verticalInput *= -1;
            horizontalInput *= -1;
        }
        if ((verticalInput != 0 || horizontalInput != 0) && isParrying == false && isKicking == false)
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
        if (isParrying == false && isKicking == false)
        {
            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        }
        
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        if ((moveDir.sqrMagnitude > 0.001f) && isParrying == false && isKicking == false)
        {
            playerObj.transform.forward = moveDir;
        }

        //Action
        if (Input.GetKeyDown(KeyCode.Space) && isParrying == false)
        {
            _animator.SetTrigger("Block");
            parrywindow = true;
            parryTimer = 0f;
            isParrying = true;
            isKicking = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && canKick && isKicking == false)
        {
            _animator.SetTrigger("Kick");
            kickTimer = 0f;
            isKicking = true;
            isParrying = false;
        }

    }

    

}
