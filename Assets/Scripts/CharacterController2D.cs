using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

//Pre-written code
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] InventoryPanel inventory;
    [SerializeField] Currency money;

    Rigidbody2D rb2D;
    Vector2 motionVector;
    Animator animator;

    public Vector2 lastMotionVector;
    public bool moving;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(horizontal, vertical);
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (moving)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.velocity = motionVector * speed;
    }

    public void OnBuy()
    {
        if(money.GetCurrentMoney() > 1000)
        {
            inventory.AddItem(4);
            inventory.AddItem(5);
            OnGetMoney(-400);
        }
    }

    public void OnSell()
    {
        if(inventory.HasItem(4) && inventory.HasItem(5))
        {
            inventory.RemoveItem(4);
            inventory.RemoveItem(5);
            OnGetMoney(400);
        }
    }

    public void OnGetMoney(int _amountGained)
    {
        money.SetMoney(money.GetCurrentMoney() + _amountGained);
    }
}
