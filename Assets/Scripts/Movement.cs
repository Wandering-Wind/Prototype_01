using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    private float movementCooldown = 2f; // Cooldown duration for movement
    private float cooldownTimer = 0f; // Timer for movement cooldown
    private bool isDoubleMove = false; // Flag to track if player's movement distance is doubled

    // Tile-based movement parameters
    public float tileSize = 1.25f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        // Update cooldown timer
        if (!canMove)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                canMove = true;
            }
        }

        // Tile-based movement
        if (canMove)
        {
<<<<<<< Updated upstream
            if (Input.GetKeyDown(KeyCode.UpArrow))
                MovePlayer(Vector3.up);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                MovePlayer(Vector3.down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                MovePlayer(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                MovePlayer(Vector3.right);
=======
            if (Input.GetKeyDown(KeyCode.UpArrow)) MovePlayer(Vector3.up);
            else if (Input.GetKeyDown(KeyCode.DownArrow)) MovePlayer(Vector3.down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) MovePlayer(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow)) MovePlayer(Vector3.right);
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        if (canMove)
        {
            float distance = isDoubleMove ? tileSize * 2f : tileSize;
            targetPosition += direction * distance;
            canMove = false;
            StopMovement(movementCooldown);

            if (turnManager != null)
            {
                turnManager.RegisterMove();
            }
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            if (powerUpManager != null)
            {
                //powerUpManager.RemovePowerUp(collision.gameObject); // Remove the power-up from the active list
            }

            Destroy(collision.gameObject);
            Debug.Log("Power-up collected! Extra move granted.");
            ShowExtraMoveIndicator(); // Display the indicator
            if (turnManager != null)
            {
                turnManager.AddExtraMove(); // Grant an extra move
            }
        }
    }

    private void ShowExtraMoveIndicator()
    {
        if (extraMoveIndicator != null)
        {
            extraMoveIndicator.SetActive(true);
            Invoke("HideExtraMoveIndicator", indicatorDisplayTime);
        }
    }

    private void HideExtraMoveIndicator()
    {
        if (extraMoveIndicator != null)
        {
            extraMoveIndicator.SetActive(false);
>>>>>>> Stashed changes
        }
    }

    public void StopMovement(float duration)
    {
        canMove = false;
        cooldownTimer = duration; // Set cooldown timer
    }

    public void SetDoubleMove(bool isDouble)
    {
        isDoubleMove = isDouble;
    }

    private void MovePlayer(Vector3 direction)
    {
        // Check if movement input is detected and movement is not on cooldown
        if (canMove)
        {
            // Calculate the movement distance based on whether the player's movement is doubled
            float distance = isDoubleMove ? tileSize * 2f : tileSize;
            targetPosition += direction * distance;
            canMove = false; // Disable movement until cooldown is over
            StopMovement(movementCooldown); // Start cooldown
        }
    }

    void LateUpdate()
    {
        // Smoothly move the player towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}
