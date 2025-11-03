using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    [SerializeField] GameObject restartText;
    public float timer = 0f;

    private void Update() {
        
        if (Input.GetKey(KeyCode.Escape)) {
            timer += Time.deltaTime;
            restartText.SetActive(true);
        }
        else {
            restartText.SetActive(false);
            timer = 0;
            return;
        }
        
        if (timer >= 3f) SceneManager.LoadScene("Nivel 1");
    }
}
