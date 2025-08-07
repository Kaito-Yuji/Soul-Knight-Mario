using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // Speed of the enemy
    [SerializeField] private float distance = 2f;
    private Vector3 startPos;
    private bool movingRight = true; // Direction of movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position; // Store the initial position of the enemy

    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance; // Left boundary
        float rightBound = startPos.x + distance; // Right boundary
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // Move right
            if (transform.position.x >= rightBound) // Check if reached right boundary
            {
                movingRight = false; // Change direction to left
                Flip(); // Flip the enemy sprite
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // Move left
            if (transform.position.x <= leftBound) // Check if reached left boundary
            {
                movingRight = true; // Change direction to right
                Flip(); // Flip the enemy sprite
            }
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale; // Get current scale
        scale.x *= -1; // Flip the x-axis scale
        transform.localScale = scale; // Apply the flipped scale
    }
}
