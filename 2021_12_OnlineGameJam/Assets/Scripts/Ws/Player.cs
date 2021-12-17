using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private const float GroundCheckDistance = 0.7f;
    private readonly Vector3 _rightDirection = new Vector3(0.5f, 1, 0);
    private readonly Vector3 _leftDirection = new Vector3(-0.5f, 1, 0);
    private Vector3 _jumpDirection;
    
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float playerWidth;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chargeTime;
    [SerializeField] private bool isCharging;
    [SerializeField] private bool isGround;
    
    private void Start()
    {
        isCharging = false;
        isGround = true;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGround();
        Jump();
        Move();
    }

    private void CheckGround()
    {
        var layerMask = 1 << LayerMask.NameToLayer("Ground");  // Ground 레이어만 필터링 해옴

        for (var i = -1; i <= 1; i++)
        {
            var position = transform.position;
            var positionX = position.x + i * (playerWidth / 2);
            position = new Vector3(positionX, position.y, 0);
            var hitObj = Physics2D.Raycast(position, Vector2.down, GroundCheckDistance, layerMask);
            Debug.DrawRay(position, Vector3.down * GroundCheckDistance, Color.red);
            isGround = !(hitObj.collider is null);
            if (isGround) break;
        }
    }

    private void Move()
    {
        if (!isGround) return;
        
        if (isCharging)
        {
            SetJumpDirection();
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isCharging)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                playerSpriteRenderer.flipX = false;
                return;

            }
            _jumpDirection = _leftDirection;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!isCharging)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                playerSpriteRenderer.flipX = true;
                return;
            }
            _jumpDirection = _rightDirection;
        }
    }

    private void SetJumpDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _jumpDirection = _leftDirection;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _jumpDirection = _rightDirection;
        }
        else
        {
            _jumpDirection = Vector3.up;
        }
    }
    
    private void Jump()
    {
        if (!isGround) return;

        if (isCharging)
        {
            if (!Input.GetKeyUp(KeyCode.Space)) return;
            isCharging = false;
            var pressTime = Time.time - chargeTime;
            var chargeForce = pressTime > 2 ? 2 : pressTime;
            playerRigidbody.AddForce(_jumpDirection * jumpForce * chargeForce);
        }
        else
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            _jumpDirection = Vector3.up;
            chargeTime = Time.time;
            isCharging = true;
        }
    }
}
