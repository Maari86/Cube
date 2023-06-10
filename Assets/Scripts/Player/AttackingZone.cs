using UnityEngine;

public class AttackingZone : MonoBehaviour
{
    public Animator animator;
    public float attackZoneSize = 1f;
    public string[] attackAnimations;

    private bool isAttacking = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cubes") && !isAttacking)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 relativePos = transform.InverseTransformPoint(other.transform.position);
                float distance = Mathf.Abs(relativePos.z);

                if (distance <= attackZoneSize)
                {
                    int index = Random.Range(0, attackAnimations.Length);
                    string animationName = attackAnimations[index];

                    animator.SetTrigger(animationName);
                    isAttacking = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cubes"))
        {
            isAttacking = false;
        }
    }
}
