using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        transform.rotation = Quaternion.identity;
        transform.localRotation = Quaternion.Euler(1, 2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
