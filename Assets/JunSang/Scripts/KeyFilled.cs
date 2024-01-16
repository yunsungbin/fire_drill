using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFilled : MonoBehaviour
{
    public KeyData key;
    public SpriteRenderer image;

    public void SetItem(KeyData _key)
    {
        key.keyName = _key.keyName;
        key.keyImage = _key.keyImage;
        key.keyType = _key.keyType;
        key.efts = _key.efts;

        image.sprite = key.keyImage;
    }
    
    public KeyData GetItem()
    {
        return key;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
