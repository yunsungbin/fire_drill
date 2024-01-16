using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryUseItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Des());
    }

    IEnumerator Des()
    {
        if(UseItem.isStop)
        {
            yield return new WaitForSeconds(1.0f);
            UseItem.isStop = false;
            yield return null;

            Destroy(gameObject);
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
