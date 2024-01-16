using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2 worldSize; //게임 상 맵의 크기
    public float nodeSize; //노드의 크기
    [SerializeField]Node[,] myNode; //전체 노드를 관리할 배열
    int nodeCountX; //노드의 X방향 개수
    int nodeCountY; //노드의 Y방향 개수
    [SerializeField] LayerMask obstacle; //장애물인지 아닌지 구분해 줄 LayerMask
     public List<Node> path; //예상 경로


    private void Start()
    {
        nodeCountX = Mathf.CeilToInt(worldSize.x / nodeSize); //노드의 크기에 따라서 개수가 달라진다.
        //노드가 커지면 개수가 작고,정확도는 낮지만 계산이 빨라지고
        //반대로 노드가 작아지면 개수가 많아져서 정확도는 올라가지만 계산속도가 느려진다.
        nodeCountY = Mathf.CeilToInt(worldSize.y / nodeSize);
        myNode = new Node[nodeCountX, nodeCountY];
        for(int i = 0; i < nodeCountX; i++)
        {
            for(int j = 0; j < nodeCountY; j++)
            {
                Vector3 pos = new Vector3(i * nodeSize - 30f, j * nodeSize - 53.4f); //노드의 좌표
                Collider2D hit = Physics2D.OverlapBox(pos, new Vector2(nodeSize/2, nodeSize/2 ), 0, obstacle);
                bool noHit = false;
                if (hit == null)  noHit = true;
                myNode[i, j] = new Node(noHit, pos,i,j); //노드를 생성해준다.
            }
        }      
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(worldSize.x, worldSize.y, 1));
        if (myNode != null)
        {
            foreach(Node no in myNode)
            {
                Gizmos.color = (no.canWalk) ? Color.white : Color.red;
                if (path != null) 
                {
                    if (path.Contains(no)) //경로에 포함이 된 노드는 검정색큐브로 표시
                    {
                        Gizmos.color = Color.black;
                    }
                }
                  Gizmos.DrawCube(no.myPos, Vector3.one * (nodeSize/2));
            }
        }
    }
    public List<Node> SearchNeightborNode(Node node)
    {
        
        List<Node> nodeList = new List<Node>();
        for(int i = -1; i < 2; i++) 
        {
            for(int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue; //9가지 방향 중 (0,0)방향은 자기 자신이기때문에 생략

                int newX = node.myX + i;
                int newY = node.myY + j;

                if (newX >= 0 && newY >= 0 && newX < nodeCountX && newY < nodeCountY)
                {
                    nodeList.Add(myNode[newX,newY]);
                }
            }
        }
        return nodeList;
    }

    public Node GetNodeFromVector(Vector3 vector) 
    {
        int posX = Mathf.FloorToInt((vector.x + worldSize.x / 2) / nodeSize);
        int posY = Mathf.FloorToInt((vector.y + worldSize.y / 2) / nodeSize);

    // 수정: 배열 범위를 확인하여 유효한 노드인지 체크
        if (posX >= 0 && posY >= 0 && posX < nodeCountX && posY < nodeCountY)
        {
            return myNode[posX, posY];
        }
        else
        {
            Debug.LogError("GetNodeFromVector: 인덱스가 배열 범위를 벗어났습니다. posX: " + posX + ", posY: " + posY);
            return null;
        }
    }
}
