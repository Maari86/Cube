using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ParticleSystem particleEffectPrefab;
    public float destroyDelay = 5f; // Delay in seconds before destroying particle systems
    private bool hasTriggered = false;
    private List<ParticleSystem> clonedParticleSystems = new List<ParticleSystem>();

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Slicer"))
        {
            if (particleEffectPrefab != null)
            {
                ParticleSystem particle = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
                particle.Play();
                clonedParticleSystems.Add(particle);
                hasTriggered = true;

                StartCoroutine(DestroyParticleSystems());
            }
        }
    }

    private IEnumerator DestroyParticleSystems()
    {
        yield return new WaitForSeconds(destroyDelay);

        foreach (ParticleSystem ps in clonedParticleSystems)
        {
            Destroy(ps.gameObject);
        }

        clonedParticleSystems.Clear();
    }
}
