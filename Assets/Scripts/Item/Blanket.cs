using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanket : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curveUp;
    [SerializeField]
    private AnimationCurve curveDown;

    private float MaxHeigh = 5;
    private float CurveTime = 0.2f;


    private void Awake()
    {
        StartCoroutine(Curve());
    }

    private IEnumerator Curve()
    {
        Vector3 startPos = transform.localPosition;
        Vector3 targetPos = startPos + new Vector3(0, MaxHeigh, 0);
        if (UseItem.Left == true)
        {
            targetPos = startPos + new Vector3(-2, MaxHeigh, 0);
        }
        if (UseItem.Left == false)
        {
            targetPos = startPos + new Vector3(2, MaxHeigh, 0);
        }


        float timer = 0.0f;

        while(timer < CurveTime)
        {
            timer += Time.deltaTime;
            float Complete = timer / CurveTime;
            transform.localPosition = Vector3.Lerp(startPos, targetPos, curveUp.Evaluate(Complete));
            yield return null;
        }
        timer = 0.0f;
        startPos = transform.localPosition;
        targetPos = startPos + new Vector3(0, -MaxHeigh, 0);
        if (UseItem.Left == true)
        {
            targetPos = startPos + new Vector3(-2, -MaxHeigh, 0);
        }
        if (UseItem.Left == false)
        {
            targetPos = startPos + new Vector3(2, -MaxHeigh, 0);
        }

        while (timer < CurveTime)
        {
            timer += Time.deltaTime;
            float Complete = timer / CurveTime;
            transform.localPosition = Vector3.Lerp(startPos, targetPos, curveDown.Evaluate(Complete));
            yield return null;
        }
    }
}
