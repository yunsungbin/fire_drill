using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    public static TestGameManager Instance;

    public float musicVolume;
    public float sfxVolume;
    public enum GANESTATION : int{
        READY,
        PLAY = 20,
        STOP,
        OPTIONUI = 30,
        END
    }


    public GANESTATION gameStation;
    // Start is called before the first frame update
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            if(Instance != this){
                Destroy(gameObject);
            }
        }

    }
    public void GameStart(){
        gameStation = GANESTATION.PLAY;
    }

    void OnEnable(){
        musicVolume = 1.0f;
        sfxVolume = 1.0f;
    }
}
