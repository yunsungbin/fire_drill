using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject Fires;
    private float fireSpawnTime = 5;
    private float time;

    private void Awake()
    {
        fireSpawnTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    private void Spawn(){
        if(time >= fireSpawnTime){
            Instantiate(Fires, transform.position, Quaternion.identity);
            if(time > 200){
                fireSpawnTime += 3;
            }
            else if(time > 100){
                fireSpawnTime += 4;
            }
            else{
                fireSpawnTime += 5;
            }
        }
        else{
            time = Time.deltaTime;
        }
    }
}
