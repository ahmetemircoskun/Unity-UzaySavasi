using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuLazer : MonoBehaviour
{

    Rigidbody fizik;

    [SerializeField] float hiz;



    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        
    }


    void FixedUpdate()
    {

        fizik.linearVelocity = transform.forward * hiz;

    }
}
