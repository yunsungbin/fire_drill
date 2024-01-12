using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector2 inputVec = new Vector2();
    [SerializeField]
    private float Speed;
    //[SerializeField]
    //private RuntimeAnimatorController AnimCon;

    private SpriteRenderer sprite;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        Vector2 nextMove = inputVec * Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextMove);
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if(inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
    }
}
