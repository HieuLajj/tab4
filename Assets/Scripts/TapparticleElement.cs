using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapparticleElement : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem particleSystem;
    private Renderer renderer;
    void Awake()
    {
        particleSystem =  transform.GetComponent<ParticleSystem>();
        renderer = particleSystem.GetComponent<Renderer>();
    }


    public void SetUp(Material material)
    {
        if (material == null) return;
        renderer.material = material;
    }
}
