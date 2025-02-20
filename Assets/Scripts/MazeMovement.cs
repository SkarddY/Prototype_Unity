using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class MazeMovement : MonoBehaviour
{
    [SerializeField] Transform spawnPos, itemPos;
    [SerializeField] UnityEvent onPickObject, OnGameEnd;
    [SerializeField] GameObject itemMaze;
    [SerializeField] Animation itemMazeAnim;
    public float moveSpeed = 5f;
    void Start()
    {
        transform.position = spawnPos.position; // Start at snap point
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
    }
    public void PickObject(){
        itemMazeAnim.Stop();
        itemMaze.transform.SetParent(itemPos.transform);
        itemMaze.transform.position = itemPos.position;
        Debug.Log("Picking object");
    }
}
