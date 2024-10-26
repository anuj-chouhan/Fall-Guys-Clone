using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPendulum : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float limit = 75f; //Limit in degrees of the movement
    [SerializeField] private bool randomStart = false; //If you want to modify the start position

	private float random = 0;
	private void Awake()
    {
        if (randomStart)
        {
            random = Random.Range(0f, 1f);
        }
    }

    private void Update()
    {
        // Get the current localEulerAngles of the object
        Vector3 currentRotation = transform.localEulerAngles;

        // Calculate the pendulum angle for the Z-axis
        float angle = limit * Mathf.Sin(Time.time + random * speed);
        // Update only the Z-axis while keeping X and Y unchanged
        currentRotation.z = angle;

        // Apply the updated rotation back to the transform
        transform.localEulerAngles = currentRotation;
    }
}
