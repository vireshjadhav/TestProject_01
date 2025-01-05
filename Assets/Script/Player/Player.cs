using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // variables to move 
    private Rigidbody2D rb;
    private float horizontalInput, verticalInput;
    public float speed = 1f;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start() => rb = GetComponent<Rigidbody2D>();

    // Update is called once per frame
    void Update() => GetInput();

    void FixedUpdate() =>  MovePlayer();

    // methode to get input
    public void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log($"Horizontal: {horizontalInput} Vertical: {verticalInput}");
    }
    
    //method to move player with velocity
    private void MovePlayer()
    {
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        levelManager.OnPlayerDeath();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }
}