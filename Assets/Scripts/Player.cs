using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;

    [SerializeField] private LayerCheack layerCheack;
    [SerializeField] private int money;


    private int isGroundAnim = Animator.StringToHash("isGround");
    private int isRunningAnim = Animator.StringToHash("isRunning");
    private int verticalVelocityAnim = Animator.StringToHash("vertical-velocity");

    private SpriteRenderer sprite;
    private Animator animator;
    private Rigidbody2D _rigidbody;
    private bool move = false;
    private Vector2 dir;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
    }
    private bool isGround()
    {
        return layerCheack.IsTochingLayer;
    }
    public void addMoney(int price)
    {
        money += price;
        print(price);
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(dir.x * speed, _rigidbody.velocity.y);
        if (isGround())
        {
            _rigidbody.AddForce(Vector2.up * forceJump * dir.y, ForceMode2D.Impulse);
        }
        animator.SetBool(isGroundAnim, isGround());
        animator.SetBool(isRunningAnim, move);
        animator.SetFloat(verticalVelocityAnim, _rigidbody.velocity.y);
        rotation();
    }
    private void rotation()
    {
        if (dir.x > 0) sprite.flipX = false; 
        else if (dir.x < 0) sprite.flipX = true; 
    }
    public void Movement(Vector2 direction)
    {
        if(direction.magnitude != 0)
        {
            dir = direction;
            move = true;
            return;
        }
        dir = new Vector2(0,0);
        move = false;
    }
}
