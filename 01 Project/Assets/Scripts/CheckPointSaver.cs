using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSaver : MonoBehaviour
{
    [SerializeField] private Transform checkPointPosition;

    private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<CharacterControls>().checkPoint = checkPointPosition.position;
			Destroy(gameObject);
		}
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
        Gizmos.DrawSphere(checkPointPosition.position, .25f);
	}
}


