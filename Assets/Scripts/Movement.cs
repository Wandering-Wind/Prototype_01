using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    private bool isDoubleMove = false; // Flag to track if player's movement distance is doubled

    // Basic movement parameters
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    // Tile-based movement parameters
    public float tileSize = 1.25f;
    private Vector3 targetPosition;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    void Update()
    {
        // Tile-based movement
        if (canMove && !isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                MovePlayer(Vector3.up);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                MovePlayer(Vector3.down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                MovePlayer(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                MovePlayer(Vector3.right);
        }
    }
    
    public void StopMovement(float duration)
    {
        canMove = false;
        Invoke("EnableMovement", duration);
    }

    public void SetDoubleMove(bool isDouble)
    {
        isDoubleMove = isDouble;
    }

    private void EnableMovement()
    {
        canMove = true;
    }

    // Method to move the player to the next tile
    private void MovePlayer(Vector3 direction)
    {
        // Calculate the movement distance based on whether the player's movement is doubled
        float distance = isDoubleMove ? tileSize * 2f : tileSize;
        targetPosition = transform.position + direction * distance;
        isMoving = true;
        canMove = true;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movSpeed * Time.fixedDeltaTime);

            // Check if reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Snap to the target position
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}
