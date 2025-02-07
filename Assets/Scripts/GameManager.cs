using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onLogIn, onLoseScreen;
    [SerializeField] private GameObject errorPanel;
    
    public static GameManager Instance {get; private set;}

   public void LogIn(){
        onLogIn.Invoke();
    }

    public void LoseScreen(){
        onLoseScreen.Invoke();
        StartCoroutine(DoRestart());
    }

    public void ErrorButton(){
        StartCoroutine(DoError());
    }

    IEnumerator DoRestart(){
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(0);
    }

    IEnumerator DoError(){
        errorPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        errorPanel.SetActive(false);
    }

    public void OnStartGame(){
        SceneManager.LoadScene(1);
    }

    public void OnMenuReturn(){
        SceneManager.LoadScene(0);
    }
}
