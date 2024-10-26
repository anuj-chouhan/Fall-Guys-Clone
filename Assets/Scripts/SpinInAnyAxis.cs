using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinInAnyAxis : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Axises axises;

    public enum Axises
    {
        x,
        y,
        z
    }

    private void Start()
    {
        // Apply a random offset to the initial rotation for the specific axis
        float randomDegree = Random.Range(0f, 360f);

        switch (axises)
        {
            case Axises.x:
                transform.Rotate(randomDegree, 0f, 0f, Space.Self); // Rotate only on the x-axis
                break;
            case Axises.y:
                transform.Rotate(0f, randomDegree, 0f, Space.Self); // Rotate only on the y-axis
                break;
            case Axises.z:
                transform.Rotate(0f, 0f, randomDegree, Space.Self); // Rotate only on the z-axis
                break;
        }
    }

    private void Update()
    {
        // Rotate based on the selected axis
        switch (axises)
        {
            case Axises.x:
                transform.Rotate(Vector3.right * Time.deltaTime * speed);
                break;
            case Axises.y:
                transform.Rotate(Vector3.up * Time.deltaTime * speed);
                break;
            case Axises.z:
                transform.Rotate(Vector3.forward * Time.deltaTime * speed);
                break;
        }
    }
}
