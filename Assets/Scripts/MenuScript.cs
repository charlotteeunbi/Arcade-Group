using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public AudioSource buttonClick;
    

    public void restartGame() {
        StartCoroutine(click2());
        
    }
    public void PlayGame() {
        StartCoroutine(click());
    }

    IEnumerator click() {

        buttonClick.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("SampleScene");
        
    }

    IEnumerator click2() {

        buttonClick.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("TitleScene");
    }
}
