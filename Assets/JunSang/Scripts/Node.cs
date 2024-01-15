using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool canWalk;
    public Vector3 myPos;
    public int myX;
    public int myY;
    public int gCost;
    public int hCost;

    public Node par;
    public Node(bool walk,Vector3 pos,int X,int Y)
    {
        canWalk = walk; //지나갈 수 있는 노드인지
        myPos = pos; //노드의 게임 내 vector값
        myX = X;  //노드의 x좌표 값
        myY = Y;  //노드의 y좌표 값
    }
    public int fcost
    {
        get { return gCost + hCost; }
    }
}
