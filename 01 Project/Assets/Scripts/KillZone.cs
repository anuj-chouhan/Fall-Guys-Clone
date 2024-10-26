using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnValidate()
    {
        if (GetComponent<BoxCollider>() == null)
        {
            Debug.LogError("There is no box collider in kill zone script");
        }
        else
        {
            if (GetComponent<BoxCollider>().isTrigger == false)
            {
                Debug.LogError("Turn On Trigger on box collider");
            }
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}
