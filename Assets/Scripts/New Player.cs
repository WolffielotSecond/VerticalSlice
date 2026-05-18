using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
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
    private bool isAiming = false;
    private bool isCrouching = false;
    private float normalSpeed;
    private bool pendingStopAiming = false;

    [Space]
    [Header("Aim Ray Cast")]
    public LayerMask selectableLayer;
    public float rayDistance = 100f;
    public bool drawGizmos = true;
    public float gizmoSphereSize = 0.2f;
    private Vector3 RaylastHitPoint;
    private bool RayhasHit;

    [Space]
    [Header("No editing")]
    public float actionMoveYaw;
    public float pendingMoveYaw;
    public bool hasPendingYaw;
    private bool wHeld, aHeld, sHeld, dHeld;
    public bool isShooting = false;
    private void Awake()
    {
        normalSpeed = moveSpeed;
    }
    public bool GetParrying()
    {
        return parrywindow;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //_animator = playerObj.GetComponent<Animator>();
        actionMoveYaw = Singleton.Instance._mainCamera.transform.eulerAngles.y;

    }

    public void DoCameraShake()
    {
        Singleton.Instance._mainCamera.GetComponent<MainCamera>().StartCoroutine(Singleton.Instance._mainCamera.GetComponent<CameraShake>().Shake(0.15f, 0.4f));
    }

    public void SetCanKick(bool value)
    {
        canKick = value;
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
        //获取现在相机的朝向
        pendingMoveYaw = Singleton.Instance._mainCamera.transform.eulerAngles.y;
        bool newW = Input.GetKey(KeyCode.W);
        bool newA = Input.GetKey(KeyCode.A);
        bool newS = Input.GetKey(KeyCode.S);
        bool newD = Input.GetKey(KeyCode.D);
        bool noMovementInput =
            !newW &&
            !newA &&
            !newS &&
            !newD;
        if (hasPendingYaw && noMovementInput)
        {
            // 真正切换移动方向
            actionMoveYaw = pendingMoveYaw;

            // 清除等待状态
            hasPendingYaw = false;
        }

        wHeld = newW;
        aHeld = newA;
        sHeld = newS;
        dHeld = newD;

        Vector2 input = Vector2.zero;

        if (newW) input.y += 1;
        if (newS) input.y -= 1;
        if (newD) input.x += 1;
        if (newA) input.x -= 1;

        input = Vector2.ClampMagnitude(input, 1f);

        Quaternion camRot = Quaternion.Euler(0f, actionMoveYaw, 0f);

        Vector3 forward = camRot * Vector3.forward;
        Vector3 right = camRot * Vector3.right;



        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        //Debug.Log("Vertical Input: " + verticalInput);
        //Debug.Log("Horizontal Input: " + horizontalInput);
        //if didn't receive input of wsad, set shouldInvertMovement to shouldBeInvertMovement

        if (Mathf.Abs(verticalInput) < 1 && Mathf.Abs(horizontalInput) == 0)
        {
            shouldInvertMovement = shouldBeInvertMovement;
        }

        if (shouldInvertMovement)
        {
            verticalInput *= -1;
            horizontalInput *= -1;
        }
        if ((verticalInput != 0 || horizontalInput != 0) && !isParrying && !isKicking && !isAiming)
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
        Vector3 moveDir = forward * input.y +
            right * input.x;

        // 防止斜向移动变快
        //moveDir = Vector3.ClampMagnitude(moveDir, 1f);
        if (!isParrying && !isKicking && !isAiming)
        {
            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        }

        //transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        if ((moveDir.sqrMagnitude > 0.001f) && isParrying == false && isKicking == false && !isAiming)
        {
            if (isCrouching)
            {
                // 先朝向 moveDir，再顺时针旋转45度
                playerObj.transform.forward = Quaternion.Euler(0, 45f, 0) * moveDir;
            }
            else
            {
                playerObj.transform.forward = moveDir;
            }
        }

        //Action
        if (Input.GetKeyDown(KeyCode.Space) && isParrying == false && this.gameObject.GetComponent<Player_Stats_Handler>().hasHatchet && !isAiming)
        {
            _animator.SetTrigger("Block");
            parrywindow = true;
            parryTimer = 0f;
            isParrying = true;
            isKicking = false;
            Debug.Log(Variables.Object(gameObject).Get<GameObject>("enemy ref") != null);
            if (Variables.Object(gameObject).Get<GameObject>("enemy ref") != null)
            {
                //face the enemy when parrying
                playerObj.transform.LookAt(Variables.Object(gameObject).Get<GameObject>("enemy ref").transform);
                Debug.Log("Player is parrying and facing the enemy");
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && canKick && !isKicking && !isAiming)
        {
            _animator.SetTrigger("Kick");
            kickTimer = 0f;
            isKicking = true;
            isParrying = false;
            if (Variables.Object(gameObject).Get<GameObject>("enemy ref") != null)
            {
                //face the enemy when parrying
                playerObj.transform.LookAt(Variables.Object(gameObject).Get<GameObject>("enemy ref").transform);
                Debug.Log("Player is parrying and facing the enemy");
                Variables.Object(gameObject).Get<GameObject>("enemy ref").GetComponent<ZombieStatsRegulator>().TakeDamage(50);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)/* && this.gameObject.GetComponent<Player_Stats_Handler>().hasPistol*/)
        {
            _animator.SetBool("Aiming", true);
            isAiming = true;
            isParrying = false;
            isKicking = false;
            pendingStopAiming = false;
            if (isCrouching)
            {
                isCrouching = false;
                _animator.SetBool("Is Crouching", false);
                moveSpeed = normalSpeed;
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (isShooting)
            {
                pendingStopAiming = true;
            }
            else
            {
                _animator.SetBool("Aiming", false);
                isAiming = false;
            }
        }
        if (pendingStopAiming && !isShooting)
        {
            pendingStopAiming = false;
            _animator.SetBool("Aiming", false);
            isAiming = false;    
        }
        if (Input.GetKeyDown(KeyCode.C) && !isAiming)
        {
            isCrouching = !isCrouching;
            _animator.SetBool("Is Crouching", isCrouching);
            if (isCrouching)
            {
                moveSpeed = normalSpeed * 0.75f;
            }
            else
            {
                moveSpeed = normalSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isAiming && !isShooting)
        {
            _animator.SetTrigger("Shoot");
            isShooting = true;
            HasShotEnemy();
        }
        if (isAiming)
        {
            FaceMousePoint();
        }
    }
    
    void FaceMousePoint()
    {
        Ray ray = Singleton.Instance._mainCamera.GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, selectableLayer))
        {
            RaylastHitPoint = hit.point;
            RayhasHit = true;

            Vector3 lookDir = hit.point - transform.position;

            // 只保留水平旋转，防止模型抬头低头
            lookDir.y = 0f;

            if (lookDir.sqrMagnitude > 0.001f)
            {
                playerObj.transform.forward = lookDir.normalized;
            }
        }
    }

    public void HasShotEnemy()
    {
        Ray ray = Singleton.Instance._mainCamera.GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, selectableLayer))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            Debug.Log("Hit tag: " + hit.collider.gameObject.tag);
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Hit!");
                IDamagable damageable = hit.collider.GetComponent<IDamagable>();

                if (damageable != null)
                {
                    damageable.DealDamage(10);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if (!drawGizmos || !RayhasHit)
            return;

        Gizmos.DrawSphere(RaylastHitPoint, gizmoSphereSize);
        Gizmos.DrawLine(transform.position, RaylastHitPoint);
    }


}
