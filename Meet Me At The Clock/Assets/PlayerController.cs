using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public GameObject Player;
    public GameObject MazeGoal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MazeGoal")
        {
            SceneManager.LoadScene("StorageRoom");
        }
    }
}
