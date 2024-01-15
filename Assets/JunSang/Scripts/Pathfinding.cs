using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Grid grid;
    private void Start()
    {
        grid = GetComponent<Grid>();
    }
    public List<Node> PathFind(Vector3 startPos,Vector3 endPos) //출발점과 도착점을 받는다.
    {
        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>(); //closedlist는 포함되어있는지만 확인하기 때문에 hashset으로
        Node startNode = grid.GetNodeFromVector(startPos); //위에서 만들었던 함수이다.
        Node endNode = grid.GetNodeFromVector(endPos);
        openList.Add(startNode); //openList에 시작점을 넣고
        while (openList.Count > 0)
        {
            Node curNode = openList[0];//curNode를 openList의 첫 노드로
           
            for(int i = 1; i < openList.Count; i++) //만약 openList에 다른 노드가 더 있다면, 비교해서 최선의 노드를 찾는다.
            {
                if (openList[i].fcost < curNode.fcost || openList[i].fcost == curNode.fcost)
                { //최적의 노드를 탐색하는 과정. fcost가 가장 낮은 노드가 curNode가 된다.
                 
                    curNode = openList[i]; 
                }
            }
            openList.Remove(curNode); 
            closedList.Add(curNode);  //closedList에 탐색을 한 현재 노드를 넣는다.    
            if(curNode==endNode)
            {   //현재노드가 도착지라면 탐색을 종료하고 endNode부터 역방향으로 탐색을 시작한다.
                 return Retrace(startNode, curNode);             
            }       
            foreach (Node neightborNode in grid.SearchNeightborNode(curNode))
            {
             //주변 노드들을 불러오는 함수
                if (neightborNode.canWalk && !closedList.Contains(neightborNode))
                {     //주변 노드중에 접근이 가능하고, closedList에 없는 노드만 접근한다.
                    int x = curNode.myX - neightborNode.myX;
                    int y = curNode.myY - neightborNode.myY;
                    int newCost = curNode.gCost + GetDistance(neightborNode, curNode);
                   //getDistance라는 함수는 노드 사이의 거리를 잴 때 사용
                    if (newCost < neightborNode.gCost || !openList.Contains(neightborNode))
                    { //오픈리스트에 위 노드가 없거나,있어도 새로 구한 gcost 가 더 작을경우엔
                    //gcost를 다시 계산한 값으로 넣어준다. 또한 par노드 또한 변경해준다.
                        neightborNode.gCost = newCost;
                        neightborNode.hCost = GetDistance(neightborNode, endNode);
                        neightborNode.par = curNode;
                        
                        if (!openList.Contains(neightborNode)) {openList.Add(neightborNode); }
                    }
                }
            }
        }
        return null; //만약 모든 노드를 탐색했는데 목적지를 찾지 못 하면 null값을 반환
    }
    List<Node> Retrace(Node start,Node end) //목적지 노드를 방문했을 때 호출되는 함수
    {
        List<Node> path = new List<Node>();
        Node curNode = end;
        while (curNode != start)
        {
         //각각의 par들을 계속해서 방문해주고,리스트에 넣은다.      
            path.Add(curNode);
            curNode = curNode.par;
        }
        path.Reverse();
        //그 후 완성된 리스트를 역정렬 해주면 출발점부터 도착점까지가 된다.
        grid.path = path;
        return path;
    }
    int GetDistance(Node aNode,Node bNode) //두가지 노드가 주어지면 거리 가중치를 계산하는 함수이다.
    {
        int x = Mathf.Abs(aNode.myX - bNode.myX);
        int y = Mathf.Abs(aNode.myY - bNode.myY);
        //절대값으로 계산을 해주고, 절대값이 더 작은만큼은 대각선으로 이동하는게 합리적이고,초과치는 직선으로 이동한다. 
        if (x > y) return 14 * y + 10 * (x - y);
        return 14 * x + 10 * (y - x);
    }
}
