using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rollerWithThornsPrefab;
    [SerializeField] private float spawnRollerTimerMax;
    [SerializeField] private float destroyAfterTime;
    [SerializeField] private float forceSpeed = 5;

    private float spawnRollerTimer;
    private void Update()
    {
        SpawnRoller();
    }
    private void SpawnRoller()
    {
        spawnRollerTimer -= Time.deltaTime;
        if (spawnRollerTimer < 0)
        {
            spawnRollerTimer = spawnRollerTimerMax;
            InstantiateAndThrowRoller();
        }
    }
    private void InstantiateAndThrowRoller()
    {
        GameObject thisRoller = Instantiate(rollerWithThornsPrefab, transform.position, transform.localRotation);

        Destroy(thisRoller, destroyAfterTime);

        //Roller Physics
        Rigidbody ThisRollerRigidbody = thisRoller.GetComponent<Rigidbody>();

        // Apply force in the chosen direction
        ThisRollerRigidbody.AddForce(transform.forward * forceSpeed, ForceMode.Impulse);

        // Apply torque to make the roller spin in the chosen direction
        ThisRollerRigidbody.AddTorque(transform.right * forceSpeed * .25f, ForceMode.Impulse);

        //Make This Rigidbody null
        ThisRollerRigidbody = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(transform.position, .5f);
    }
}

