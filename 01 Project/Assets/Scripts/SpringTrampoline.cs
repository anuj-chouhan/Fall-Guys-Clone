using NaughtyAttributes;
using UnityEngine;

public class SpringTrampoline : MonoBehaviour
{
    [SerializeField] private float pushForce;
    [AnimatorParam("_springAnimator")][SerializeField] private string animatorParameter;

    public Animator _springAnimator;
    public Collider _springCollider;
    
    private void OnValidate()
    {
        _springAnimator = GetComponent<Animator>();
        _springCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Catch player rigidbody and add force
            Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
            playerRb.AddForce(Vector3.up * pushForce);

            _springAnimator.SetTrigger(animatorParameter);
            _springCollider.isTrigger = false;

            other.gameObject.GetComponent<CharacterControls>().HitPlayer(Vector3.up * pushForce, 0f);
        }
    }

    private void ReactivateSpring()
    {
        _springCollider.isTrigger = true;
    }
}
