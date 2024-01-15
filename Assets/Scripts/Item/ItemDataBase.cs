using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();
    [Space(20)]
    public GameObject filedItemPrefab;
    public Vector3[] pos;

    private void Start()
    {
        for(int index = 0; index < 6; index++)
        {
            GameObject go = Instantiate(filedItemPrefab, pos[index], Quaternion.identity);
            go.GetComponent<FiledItem>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
