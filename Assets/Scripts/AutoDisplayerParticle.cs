using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoDisplayerParticle : MonoBehaviour
{
    // Reference to the particle system
    new ParticleSystem particleSystem;

    void Awake()
    {
        // Get the reference to the particle system
        particleSystem = GetComponent<ParticleSystem>();
      
    }

    private void OnEnable()
    {
        StartCoroutine(DisalbeOjbect());
    }

    IEnumerator DisalbeOjbect()
    {
        yield return new WaitForSeconds(particleSystem.main.duration);
        gameObject.SetActive(false);
    }
    
}
