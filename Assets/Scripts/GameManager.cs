using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject errorPanel;
    
    public void ErrorButton(){
        StartCoroutine(DoError());
    }

    IEnumerator DoError(){
        errorPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        errorPanel.SetActive(false);
    }

    public void OnReporteLoad() {
        StartCoroutine(DoError());
        //SceneManager.LoadScene("Nivel 0");
    }
    public void OnLvl1Load() {
        SceneManager.LoadScene("Nivel 1");
    }
    public void OnLvl2Load() {
        StartCoroutine(DoError());
        //SceneManager.LoadScene("Nivel 2");
    }
    public void OnLvl3Load() {
        StartCoroutine(DoError());
        //SceneManager.LoadScene("Nivel 3");
    }
    public void OnExitButton() {
        Debug.Log("Closing App");
        Application.Quit();
    }
}
