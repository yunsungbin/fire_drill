using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static Key Instance;

    void Awake(){
        Instance = this;
    }

    public GameObject key;
    public Vector3[] pos;

    void Start(){
        Vector3 keyPos = pos[Random.Range(0, pos.Length)];
        GameObject obj = Instantiate(key, keyPos, Quaternion.identity);
    }
}
