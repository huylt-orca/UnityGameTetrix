using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionController : MonoBehaviour
{
    public GameObject popupHowToPlay;
    public Scrollbar scrollbar;
    public GameObject barrierAudio;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.mute = PlayerPrefs.GetInt("AudioMute",0) == 0 ? true : false;
        barrierAudio.SetActive(audioSource.mute);
        scrollbar.value = PlayerPrefs.GetFloat("AudioValue", 1);
        scrollbar.onValueChanged.AddListener(delegate { ScrollbarValueChange(); });
    }

    private void ScrollbarValueChange()
    {
        PlayerPrefs.SetFloat("AudioValue", scrollbar.value);
    }

    

    public void Mute()
    {
        
        audioSource.mute = !audioSource.mute;
        barrierAudio.SetActive(audioSource.mute);
        PlayerPrefs.SetInt("AudioMute", audioSource.mute ? 0 : 1);
    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ShowPopupHowToPlay()
    {
        popupHowToPlay.SetActive(true);
    }

    public void ClosePopupHowToPlay()
    {
        popupHowToPlay.SetActive(false);
    }

}
