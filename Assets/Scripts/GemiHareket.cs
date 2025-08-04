using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;



[System.Serializable]
public class Sinirlar
{
    public float xMin, xMax, zMin, zMax;
}

public class GemiHareket : MonoBehaviour
{
    
    Rigidbody hareket;
    
    [SerializeField] float hiz;
    [SerializeField] float egimX, egimZ;
    [SerializeField] float siradaki_zaman, gecikme;

    public GameObject oyuncu_ates, ates_spawn;

    public Sinirlar sinirlar;

    void Start()
    {

        hareket = GetComponent<Rigidbody>();    
    }

    void Update() 
    
    {
        if(Input.GetButton("Jump") && Time.time > siradaki_zaman)
        {
            siradaki_zaman = Time.time + gecikme;

            Instantiate(oyuncu_ates, ates_spawn.transform.position, ates_spawn.transform.rotation);
        }
        
    }

   
    void FixedUpdate()
    {   

        float yatayhareket = Input.GetAxis("Horizontal");
        float dikeyhareket = Input.GetAxis("Vertical");

        Vector3 hareketvektor = new Vector3(yatayhareket, 0 ,dikeyhareket);

        hareket.linearVelocity = hareketvektor * hiz;



        Vector3 pozisyonvektor = new Vector3(

            Mathf.Clamp(hareket.position.x, sinirlar.xMin, sinirlar.xMax),
            1,
            Mathf.Clamp(hareket.position.z, sinirlar.zMin, sinirlar.zMax)
        );

        hareket.position = pozisyonvektor;



        hareket.rotation = Quaternion.Euler(dikeyhareket*egimX, 0, -yatayhareket*egimZ);
    }
}
