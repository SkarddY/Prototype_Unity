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

    public void OnStartGame(){
        SceneManager.LoadScene(1);
    }

    public void OnMenuReturn(){
        SceneManager.LoadScene(0);
    }

    public void OnReporteLoad() {
        SceneManager.LoadScene("Nivel 0");
    }
    public void OnLvl1Load() {
        SceneManager.LoadScene("Nivel 1");
    }
    public void OnLvl2Load() {
        SceneManager.LoadScene("Nivel 2");
    }
    public void OnLvl3Load() {
        SceneManager.LoadScene("Nivel 3");
    }
    public void OnLvl4Load() {
        SceneManager.LoadScene("Nivel 4");
    }
    
}
