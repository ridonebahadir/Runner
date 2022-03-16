using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleToTarget : MonoBehaviour
{
    private Transform Target;

    private ParticleSystem system;

    private static ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1000];
    int count;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("CoinTarget").gameObject.transform;
        if (system == null)
            system = GetComponent<ParticleSystem>();

        if (system == null)
        {
            this.enabled = false;
        }
        else
        {
            system.Play();
        }
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        count = system.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle particle = particles[i];

            Vector3 v1 = system.transform.TransformPoint(particle.position);
            Vector3 v2 = Target.transform.position;

           
            Vector3 tarPosi = (v2 - v1) * (particle.lifetime / particle.startLifetime);
            particle.position = system.transform.InverseTransformPoint(v2 - tarPosi);
            particles[i] = particle;
        }

        system.SetParticles(particles, count);
    }
}
