using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    private float movementCooldown = 2f;
    private float cooldownTimer = 0f;
    private bool canPassGates = false; // New variable to control gate passing

    public float tileSize = 1.25f;
    private Vector3 targetPosition;

    private TurnManager turnManager;

    void Start()
    {
        targetPosition = transform.position;
        turnManager = FindObjectOfType<TurnManager>();
    }

    void Update()
    {
        if (!enabled) return;

        if (!canMove)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                canMove = true;
            }
        }

        if (canMove)
        {
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
            float distance = tileSize;
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

    public void StopMovement(float duration)
    {
        canMove = false;
        cooldownTimer = duration;
    }

    public void AllowGatePass(int turns)
    {
        canPassGates = true;
        StartCoroutine(GatePassCooldown(turns));
    }

    private IEnumerator GatePassCooldown(int turns)
    {
        yield return new WaitForSeconds(turns * movementCooldown); // Assuming movementCooldown is the turn duration
        canPassGates = false;
    }
}
