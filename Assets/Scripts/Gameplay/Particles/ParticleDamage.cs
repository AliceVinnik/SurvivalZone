using System.Collections;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private Pooled pooled;

    public float timeToReturnToPull = 999f;

    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        pooled = GetComponent<Pooled>();

        timeToReturnToPull = particleSystem.main.duration;
    }

    public void Show(Vector3 position)
    {
        transform.position = position;

        particleSystem.Play();
    }

    public IEnumerator ReturnToPoolWihtDelay()
    {
        yield return new WaitForSeconds(timeToReturnToPull);

        pooled.ReturnToPull();
    }
}
