using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

[Serializable]
public class Sound{                   // 사운드 클립과 이름을 관리하기 위해 사용
    public string name;               // 이름을 지어준다
    public AudioClip clip;            // 오디오 클립
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance{get; private set;}  // static을 사용하여 싱글톤 등록

    //오디오 클립 배열
    public Sound[] musicSound;  // 사용할 사운드 선언
    public Sound[] sfxSound;    // 사용할 사운드 선언

    public AudioSource musicSource;  // 사용할 오디오 소스 선언
    public AudioSource sfxSource;    // 사용할 오디오 소스 선언

    // 오디오 옵션
    public AudioMixer mixer;                   // 사용할 오디오 믹서
    public Slider musicSlider;                 // 옵션창에서 사용할 MusicSlider
    public Slider sfxSlider;                   // 옵션창에서 사용할 SFXSlider

    const string MIXER_MUSIC = "MusicVolume";  // 사용할 Param값 (music)
    const string MIXER_SFX = "SFXVolume";      // 사용할 Param값 (sfx)

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        
    }

    void Start(){
        musicSlider.value = TestGameManager.Instance.musicVolume;
        sfxSlider.value = TestGameManager.Instance.sfxVolume;
        Init();
    }

    void SetMusicVolume(float value){
        TestGameManager.Instance.musicVolume = value;
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);  // Log10값으로 -80 ~ 0 값 볼륨을 설정할 수 있게 해준다
    }

    void SetSFXVolume(float value){
        TestGameManager.Instance.sfxVolume = value;
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);  // Log10값으로 -80 ~ 0 값 볼륨을 설정할 수 있게 해준다
    }

    public void PlayMusic(string name){  // 재생할 BGM 함수 생성
        Sound sound = Array.Find(musicSound, x => x.name == name);  // Array 람다식 name을 찾아서 반환

        if(sound == null){                  // name으로 된 wav가 없을 경우 Log 출력
            Debug.Log("Sound Not Found!");
        }
        else{
            musicSource.clip = sound.clip;  // 생성한 오디오 소스에 클립을 넣는다.
            musicSource.Play();             // 일반 Play 재생
        }
    }
    public void PlaySFX(string name){
        Sound sound = Array.Find(sfxSound, x => x.name == name);  // Array 람다식 name을 찾아서 반환

        if(sound == null){                  // name으로 된 wav가 없을 경우 Log 출력
            Debug.Log("Sound Not Found!");
        }
        else{
            sfxSource.PlayOneShot(sound.clip);  // 일반 Play 재생
        }
    }

    void Init(){
        musicSlider.onValueChanged.AddListener(SetMusicVolume);  // 슬라이더의 값이 변경 되었을 때 해당 함수를 호출한다
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);  // 슬라이더의 값이 변경 되었을 때 해당 함수를 호출한다
    }
}
