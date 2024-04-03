using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EX_NavMeshAgent_Type3 : MonoBehaviour
{
    public Transform Target;
    NavMeshAgent Agent;

    AudioSource audioSource;
    int numSamples = 1024;
    float[] samples;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        audioSource = Target.GetComponent<AudioSource>();
        samples = new float[numSamples];
    }

    void Update()
    {
        float loudness = GetLoudness();
        if (loudness > 0)
        {
            print(loudness);
            Collider[] Colliders = Physics.OverlapSphere(transform.position, 10f);
            foreach(Collider collider in Colliders)
            {
                if ("FPSController" == collider.name)
                {
                    print("detected player");
                    Agent.destination = Target.position;
                }
            }
        }
    }

    float GetLoudness()
    {
        audioSource.GetOutputData(samples, 0); // fill array with samples
        float sum = 0;
        for (int i = 0; i < numSamples; i++)
        {
            //sum += samples[i] * samples[i]; // sum squared samples
            sum += Mathf.Pow(samples[i], 2); // sum squared samples
        }
        float loudness = Mathf.Sqrt(sum / numSamples); // rms = square root of average
        return loudness * 100000;
    }
}
