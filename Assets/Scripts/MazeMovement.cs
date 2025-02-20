using UnityEngine;
using UnityEngine.Events;

public class MazeMovement : MonoBehaviour
{
    [SerializeField] Transform spawnPos, itemPos;
    [SerializeField] UnityEvent onPickObject, OnGameEnd;
    [SerializeField] GameObject itemMaze, mazeEnding;
    public float moveSpeed = 2.5f;
    private bool isCoffeePicked;
    void Start()
    {
        isCoffeePicked = false;
        mazeEnding.SetActive(false);
        transform.position = spawnPos.position; //Start at spawn point
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
    }
    public void PickObject(){
        itemMaze.transform.position = itemPos.position;
        isCoffeePicked = true;
        Debug.Log($"Is Picked {isCoffeePicked}, and setting {mazeEnding} on {onPickObject}");
    }

    public void GameEnd(){
        Debug.Log("Maze completed!");
    }
}
