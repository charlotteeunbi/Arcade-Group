using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public AudioSource buttonClick;
    public void playButton() {
        buttonClick.Play();
    }

    public void restartGame() {
        SceneManager.LoadScene("TitleScene");
        
    }
    public void PlayGame() {
        SceneManager.LoadScene("SampleScene");
    }
}
