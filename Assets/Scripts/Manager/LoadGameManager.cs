using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Stagetext;
    public static bool firstStage;

    [SerializeField]

    private Image progressBar;

    public static string nextScene;

    private void Awake()
    {
        Stage();
    }

    private void Start()
    {
        StartCoroutine(LoadingScene());
    }

    public static void LoadingScene(string sceneName)

    {

        nextScene = sceneName;

        SceneManager.LoadScene("GameLoading");

    }

    IEnumerator LoadingScene()

    {
        if (firstStage == true)
        {
            Stagetext[0].SetActive(true);
            firstStage = false;
        }
        else
        {
            Stagetext[1].SetActive(true);
        }
        yield return new WaitForSeconds(2.0f);



        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        op.allowSceneActivation = false;

        float timer = 0.0f;

        while (!op.isDone)

        {

            yield return null;



            timer += Time.deltaTime;
            if (op.progress < 0.9f) { progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer); if (progressBar.fillAmount >= op.progress) { timer = 0f; } }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f) { op.allowSceneActivation = true; yield break; }
            }
        }

    }

    private void Stage()
    {
        for(int i = 0; i < Stagetext.Length; i++)
        {
            Stagetext[i].SetActive(false);
        }
        
    }
}
