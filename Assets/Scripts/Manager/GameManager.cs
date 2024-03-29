using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Game Control")]
    public bool isLive;
    public float maxGameTime;
    [Header("Player")]
    public float health;
    public float maxHealth = 100;
    [Header("Game Object")]
    public Player player;

    public bool isClear = false;

    [SerializeField]
    private Image slider;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        health = maxHealth;
        isClear = false;
        maxGameTime = 180;
        if (!LoadGameManager.firstStage)
        {
            isClear = true;
            maxGameTime = 60;
        }
    }

    private void Update()
    {
        if (!isLive)
            return;
        maxGameTime -= Time.deltaTime;

        slider.fillAmount = health / maxHealth;

        if (maxGameTime <= 0 || health <= 0)
        {
            StartCoroutine(Menu());
        }
    }

    IEnumerator Menu()
    {
        isClear = false;
        yield return null;
        LoadingManager.LoadScene("Menu");
    }

    public void GameStart()
    {
        health = maxHealth;

        player.gameObject.SetActive(true);
        ReSume();
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void ReSume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
