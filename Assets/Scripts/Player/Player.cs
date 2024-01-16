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

    private float isAnime = 0;

    private void Awake()
    {
        isAnime = 0;
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (inputVec.x == 0 && inputVec.y == 0)
            PlayerAnimeIdle();
        if (inputVec.x != 0 || inputVec.y != 0)
        {
            anim.SetBool("Right", false);
            anim.SetBool("Back", false);
            anim.SetBool("Front", false);
        }
        OnMove();
        PlayerAnimeMove();
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

        anim.SetFloat("PosX", inputVec.x);
        anim.SetFloat("PosY", inputVec.y);

        Vector2 nextMove = inputVec * Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextMove);
    }

    private void TurnCharactor()
    {
        if (!GameManager.instance.isLive)
            return;

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

    private void PlayerAnimeMove()
    {
        if(inputVec.x != 0)
        {
            isAnime = 2;
        }
        else if(inputVec.y > 0)
        {
            isAnime = 1;
        }
        else if (inputVec.y < 0)
        {
            isAnime = 0;
        }
    }

    private void PlayerAnimeIdle()
    {
        
        if (isAnime == 2)
        {
            anim.SetBool("Right", true);
            isAnime = 2;
        }
        if (isAnime == 1)
        {
            anim.SetBool("Back", true);
            isAnime = 1;
        }
        if (isAnime == 0)
        {
            anim.SetBool("Front", true);
            isAnime = 0;
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

            //anim.SetTrigger("Dead");
            //GameManager.instance.GameOver();
        }
    }
}
