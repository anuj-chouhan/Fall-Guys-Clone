using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObjectMover : MonoBehaviour
{
    public bool refresh;
    private MoveableObject moveableObject;
    private CharacterControls characterControls;
    private void OnValidate()
    {
        moveableObject = GetComponent<MoveableObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (characterControls == null)
            {
                characterControls = other.GetComponent<CharacterControls>();
            }
            else
            {
                characterControls.StandingOnMovingPlatform(moveableObject.moveableObjectVelocity);
            }

            Debug.LogError("Something Bad Happen Here Bro");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
}
