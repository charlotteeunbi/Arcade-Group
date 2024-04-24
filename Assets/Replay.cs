using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    public AudioSource buttonClick;
    public void playButton() {
        buttonClick.Play();
    }

    public void restartGame() {
        SceneManager.LoadScene("SampleScene");
        
    }
}
