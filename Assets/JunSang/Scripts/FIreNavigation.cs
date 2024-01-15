using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FIreNavigation : MonoBehaviour
{
    [SerializeField] Pathfinding path;
    Vector3 targetPosition;
    public Transform target;
    public float speed;
    public float damage;
    public float attackDelay = 0f;
    public bool isDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;

        targetPosition = target.position;
        List<Node> newWay = path.PathFind(transform.position, targetPosition);
        if (newWay != null && newWay.Count > 0)
        {
            direction = newWay[0].myPos - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }

        // 지연 딜
        if(isDamaged == true){
            if(attackDelay < 0.5f){
                attackDelay += Time.deltaTime;
            }
            else{
                isDamaged = false;
            }
        }

    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(isDamaged == false){
                GameManager.instance.health -= damage;
                attackDelay = 0f;
                isDamaged = true;
            }
        }
    }
}
