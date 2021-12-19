using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private const KeyCode LeftKeyCode = KeyCode.A;
    private const KeyCode RightKeyCode = KeyCode.D;
    private const KeyCode FixKeyCode = KeyCode.F;
    private const KeyCode JumpKeyCode = KeyCode.Space;
    private readonly Vector3 _rightDirection = new Vector3(0.5f, 1, 0);
    private readonly Vector3 _leftDirection = new Vector3(-0.5f, 1, 0);
    private Vector3 _jumpDirection;

    [SerializeField] private GameObject jumpParticle;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private float defaultGravityScale = 1.5f;
    [SerializeField] private float fallingGravityScale = 9.8f;
    [SerializeField] private float playerWidth;
    [SerializeField] private float playerHeight;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chargeTime;
    [SerializeField] private bool isCharging;
    [SerializeField] private bool isGround;
    public bool IsGround
    {
        get => isGround;
    }
    public PlayerGauge playerGauge;

    public float maxPressTime = 1f;


    public event Action<float, float> OnGroundFall;
    public event Action<float> OnJump;

    private float startGroundY;
    private float endGroundY;
    private void Start()
    {
        isCharging = false;
        isGround = true;
    }

    // Update is called once per frame
    private void Update()
    {
        FixJump();
        CheckGround();
        SetPlayerPhysics();
        Jump();
		if (Input.GetKey(KeyCode.Space)) {
            ShowCharge();
		}
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void CheckGround()
    {
        var currentStatus = isGround;
        var layerMask = 1 << LayerMask.NameToLayer("Ground"); // Player ?�이?�만 충돌 체크??
        
        for (var i = -1; i <= 1; i++)
        {
            var position = transform.position;
            position = new Vector3(position.x + i * (playerWidth / 2), position.y - playerHeight / 2, 0);
            var hitObj = Physics2D.Raycast(position, Vector2.down, groundCheckDistance, layerMask);
            Debug.DrawRay(position, Vector3.down * groundCheckDistance, Color.red);
            isGround = !(hitObj.collider is null);

            if (isGround)
            {
                if (!currentStatus)
                {
                    playerRigidbody.velocity = new Vector2(0, 0);
                    SoundManager.Instance.PlaySFX("Fall");
                    
                    print("Fall Effect");
                }

                break;
            }
        }
    }

    private void SetPlayerPhysics()
    {
        var velocityY = playerRigidbody.velocity.y;
        
        playerRigidbody.gravityScale = velocityY < 0 ? fallingGravityScale : defaultGravityScale;

    }

    private void Move()
    {
        if (!isGround)
        {
            isCharging = false;
            return;
        }
        
        if (isCharging)
        {
            SetJumpDirection();
            return;
        }
        if (Input.GetKey(LeftKeyCode))
        {
            playerAnimator.SetBool("Move", true);
            if (!isCharging)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                // playerRigidbody.velocity = new Vector2(-moveSpeed, playerRigidbody.velocity.y);
                playerSpriteRenderer.flipX = true;
                return;

            }
            _jumpDirection = _leftDirection;
        }
        else if (Input.GetKey(RightKeyCode))
        {
            playerAnimator.SetBool("Move", true);
            if (!isCharging)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                // playerRigidbody.velocity = new Vector2(moveSpeed, playerRigidbody.velocity.y);
                playerSpriteRenderer.flipX = false;
                return;
            }
            _jumpDirection = _rightDirection;
        }
        else
        {

            playerAnimator.SetBool("Move", false);
        }
    }

    private void SetJumpDirection()
    {
        if (Input.GetKey(LeftKeyCode))
        {
            _jumpDirection = _leftDirection;
            playerSpriteRenderer.flipX = true;
        }
        else if (Input.GetKey(RightKeyCode))
        {
            _jumpDirection = _rightDirection;
            playerSpriteRenderer.flipX = false;
        }
        // else
        // {
        //    _jumpDirection = Vector3.up;
        // }
    }
    
    private void Jump()
    {
        if (!isGround) return;

        if (isCharging)
        {
            if (!Input.GetKeyUp(JumpKeyCode)) return;
            
            isCharging = false;
            var pressTime = Time.time - chargeTime;
            var chargeForce = pressTime > maxPressTime ? maxPressTime : pressTime;
            var power = animationCurve.Evaluate(chargeForce / maxPressTime);
            playerGauge.SetFill(power);
            playerRigidbody.AddForce(_jumpDirection * jumpForce * power * 2);
            if(chargeForce >= 0.3f) SoundManager.Instance.PlaySFX("Jump");
            Debug.Log($"Time : {pressTime}, Power: {power}");
            // jumpParticle.Play();
            playerAnimator.SetTrigger("Jump");
            jumpParticle.SetActive(true);
            OnJump?.Invoke(power);
        }
        else
        {
            if (!Input.GetKey(JumpKeyCode)) return;
            _jumpDirection = playerSpriteRenderer.flipX ? _leftDirection : _rightDirection;
            chargeTime = Time.time;
            isCharging = true;
            playerAnimator.SetTrigger("Charging");
        }
    }

    void ShowCharge()
	{
        float pressTime = Time.time - chargeTime;
        float chargeForce = pressTime > maxPressTime ? maxPressTime : pressTime;
        float power = animationCurve.Evaluate(chargeForce / maxPressTime);
        playerGauge.SetFill(power);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("a");
        if (collision.collider.CompareTag("Ground"))
        {
            endGroundY = collision.contacts[0].point.y;
            OnGroundFall?.Invoke(startGroundY, endGroundY);
        }
        if (isGround) return;

        if (collision.collider.CompareTag("Ground"))
        {
            var normal = collision.contacts[0].normal;
            var s = 1 - Vector2.Dot(normal, Vector2.up);
            playerRigidbody.AddForce(normal * s * 3, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("aa");
        startGroundY = transform.position.y;
    }

    public void FixJump()
    {
        if (Input.GetKey(FixKeyCode))
        {
            transform.Translate(new Vector3(0, 0.1f, 0));
        }
    }
}
