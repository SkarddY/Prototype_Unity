using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnSimButton(){
        SceneManager.LoadScene("Simulacro");
    }
}
