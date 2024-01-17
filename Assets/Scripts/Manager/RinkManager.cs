using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RinkManager : MonoBehaviour
{

    public GameObject Skip;

    [Header("Text UI")] public Text textUI;
    public GameObject textui;
    [Header("타이핑 지연 시간")] public float delayTime;
    IEnumerator startTyping;
    public string[] write;
    bool typingCheck = false;
    WaitForSeconds time;

    public int textNum = 0;

    void Start()
    {
        textui.SetActive(true);
        time = new WaitForSeconds(delayTime);
        StartCoroutine(IntroStart());
    }

    IEnumerator IntroStart()
    {
        for (int i = 0; i < 3; i++)
        {
            NextStory();
            yield return new WaitForSeconds(1.5f);
            textNum++;
        }
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.9f);
            textNum++;
        }
        for (int i = 0; i < 3; i++)
        {
            NextStory();
            yield return new WaitForSeconds(2.0f);
            textNum++;
        }
        for (int i = 0; i < 3; i++)
        {
            NextStory();
            yield return new WaitForSeconds(2.0f);
            textNum++;
        }
        yield return new WaitForSeconds(1.0f);
        textui.SetActive(false);
        LoadGameManager.LoadingScene("InGame");
    }

    void NextStory()
    {

        if (!typingCheck)
        {
            startTyping = TypingPage();
            typingCheck = true;
            StartCoroutine(startTyping);
        }
        else
        {
            // 타이핑 효과 넘기기
            if (typingCheck)
            {
                StopCoroutine(startTyping);
                textUI.text = write[textNum];
                typingCheck = false;
            }
        }
    }

    IEnumerator TypingPage()
    {
        string pageText;

        for (int i = 0; i < write[textNum].Length + 1; i++)
        {
            pageText = write[textNum].Substring(0, i);
            pageText += "<color=#00000000>" + write[textNum].Substring(i) + "</color>";
            textUI.text = pageText;
            yield return time;
        }

        typingCheck = false;
    }

    public void SKIP()
    {
        LoadGameManager.LoadingScene("InGame");
    }
}
