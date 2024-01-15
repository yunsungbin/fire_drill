using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public bool gameUIOnoffFlag = false;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Awake(){
        
    }
    void Start()
    {
        TestGameManager.Instance.gameStation = TestGameManager.GAMESTATION.PLAY;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            GameUIOnOff();
        }
    }

    void GameUIOnOff(){
        if(gameUIOnoffFlag == false && TestGameManager.Instance.gameStation == TestGameManager.GAMESTATION.PLAY){
            gameUIOnoffFlag = true;
            TestGameManager.Instance.gameStation = TestGameManager.GAMESTATION.STOP;
        }
        else if(gameUIOnoffFlag == true && TestGameManager.Instance.gameStation == TestGameManager.GAMESTATION.STOP){
            gameUIOnoffFlag = false;
            TestGameManager.Instance.gameStation = TestGameManager.GAMESTATION.PLAY;
        }
        pausePanel.SetActive(gameUIOnoffFlag);
    }
}
