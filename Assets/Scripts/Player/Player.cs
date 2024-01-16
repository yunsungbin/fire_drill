using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec = new Vector2();
    [SerializeField]
    private float Speed;

    Animator anim;

    private SpriteRenderer sprite;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void LateUpdate()
    {
        TurnCharactor();
    }

    public void OnMove()
    {
        if (!GameManager.instance.isLive || UseItem.isStop)
            return;

        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        Vector2 nextMove = inputVec * Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextMove);
    }

    private void TurnCharactor()
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
        if (sprite.flipX == true)
        {
            UseItem.Left = true;
        }
        if (sprite.flipX == false)
        {
            UseItem.Left = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
            return;

        GameManager.instance.health -= Time.deltaTime * 10;

        if (GameManager.instance.health < 0)
        {
            for (int index = 2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }

            anim.SetTrigger("Dead");
            //GameManager.instance.GameOver();
        }
    }
}
