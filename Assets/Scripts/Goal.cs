using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Player.useKey == true)
        {
            StartCoroutine(NextStage());
        }
    }

    IEnumerator NextStage()
    {
        if (GameManager.instance.isClear)
        {
            LoadGameManager.secondStage = false;
            Player.useKey = false;
            yield return null;
            LoadGameManager.LoadingScene("Menu");
        }
        if (LoadGameManager.firstStage == true)
        {
            LoadGameManager.firstStage = false;
            Player.useKey = false;
            yield return null;
            LoadGameManager.LoadingScene("InGame2");
        }
    }
}
