using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    public enum Axis { X, Y, Z }
    public Axis movementAxis = Axis.Y;  // Choose the axis of movement (X, Y, or Z)

    [SerializeField] private float speed;      // Movement speed
    [SerializeField] private float moveDistance;  // Distance to move (can be negative or positive)
    [SerializeField] private float offset;     // Initial offset for the first lap
    [SerializeField] private bool randomizeOffset = false; // Toggle random initial offset

    private bool isMovingForward = true;       // Track the direction of movement
    private Vector3 startPos;                  // Starting position of the object
    private Vector3 targetPos;                 // The target position based on the move distance

    private void Start()
    {
        // Store the starting position
        startPos = transform.position;

        // Randomize offset if enabled
        if (randomizeOffset)
        {
            offset = Random.Range(0, Mathf.Abs(moveDistance));
        }

        // Apply the initial offset for the first lap
        switch (movementAxis)
        {
            case Axis.X:
                transform.position += Vector3.right * offset;
                break;
            case Axis.Y:
                transform.position += Vector3.up * offset;
                break;
            case Axis.Z:
                transform.position += Vector3.forward * offset;
                break;
        }

        // Calculate the target position based on the move distance
        switch (movementAxis)
        {
            case Axis.X:
                targetPos = startPos + new Vector3(moveDistance, 0, 0);
                break;
            case Axis.Y:
                targetPos = startPos + new Vector3(0, moveDistance, 0);
                break;
            case Axis.Z:
                targetPos = startPos + new Vector3(0, 0, moveDistance);
                break;
        }
    }

    private void Update()
    {
        // Move along the selected axis
        switch (movementAxis)
        {
            case Axis.X:
                MoveObject(Vector3.right);
                CalculateVelocity(Vector3.right,speed);
                break;
            case Axis.Y:
                MoveObject(Vector3.up);
                CalculateVelocity(Vector3.up, speed);
                break;
            case Axis.Z:
                MoveObject(Vector3.forward);
                CalculateVelocity(Vector3.forward, speed);
                break;
        }
    }

    private void MoveObject(Vector3 direction)
    {
        if (isMovingForward)
        {
            // Move towards the target position based on the move distance
            if (Vector3.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
            else
            {
                isMovingForward = false;
            }
        }
        else
        {
            // Move backward towards the starting position
            if (Vector3.Distance(transform.position, startPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            }
            else
            {
                isMovingForward = true;
            }
        }
    }

    public Vector3 moveableObjectVelocity;
    private void CalculateVelocity(Vector3 direction, float speed)
    {
        moveableObjectVelocity = direction * speed;
    }
}
