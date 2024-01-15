using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Player player;
    Vector3 pos;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(player != null)
        {
            pos = player.transform.position;
            transform.position = new Vector3(pos.x, pos.y, pos.z - 10f);
        }
    }
}
