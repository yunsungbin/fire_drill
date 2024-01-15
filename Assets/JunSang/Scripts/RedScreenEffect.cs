using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScreenEffect : MonoBehaviour
{
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(time < 3000f){
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, time/3000);
        }
        else{
            time = 0;
            this.gameObject.SetActive(false);
            resetAnim();
        }
        time += Time.deltaTime;
    }

    public void resetAnim(){
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0);
        this.gameObject.SetActive(true);
        time = 0;
    }
}
