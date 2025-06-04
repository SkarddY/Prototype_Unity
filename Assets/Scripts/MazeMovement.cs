using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MazeMovement : MonoBehaviour
{
    [SerializeField] Transform spawnPos, itemPos;
    [SerializeField] UnityEvent onPickObject, OnGameEnd, OnMazeWorkerTalk, OnMazeWorkerEndTalk;
    [SerializeField] GameObject itemMaze, mazeEnding;
    public float moveSpeed = 2.5f;
    private bool isCoffeePicked;
    void Start()
    {
        isCoffeePicked = false;
        mazeEnding.SetActive(false);
        transform.position = spawnPos.position; //Start at spawn point
        Debug.Log("Maze Start() called!");
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MazeItem")){
            onPickObject.Invoke();
        }
        if (collision.CompareTag("MazeEnd")){
            OnGameEnd.Invoke();
        }
        if (collision.CompareTag("MazeWorker")){
            OnMazeWorkerTalk.Invoke();
            Debug.Log("Hello");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MazeWorker")){
            OnMazeWorkerEndTalk.Invoke();
        }
    }
    public void PickObject(){
        itemMaze.transform.position = itemPos.position;
        isCoffeePicked = true;
        Debug.Log($"Is Picked {isCoffeePicked}, and setting {mazeEnding} on {onPickObject}");
    }
    public void GameEnd(){
        StartCoroutine(EndMaze());
    }

    private IEnumerator EndMaze() {
        Debug.Log("Maze completed!");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
