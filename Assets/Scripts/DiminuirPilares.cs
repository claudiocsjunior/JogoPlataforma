using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiminuirPilares : MonoBehaviour
{
     bool colidiu; 

    public float alturaInicial;
    void Start()
    {
        colidiu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(colidiu){
            if(transform.position.y > -1){
                transform.localScale = new Vector3(x: transform.localScale.x, y: transform.localScale.y - 0.01f, z: transform.localScale.z);
            }else{
                transform.localScale = new Vector3(x: transform.localScale.x, y: alturaInicial, z: transform.localScale.z);
                colidiu= false;
            }   
        }
    }

     void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            colidiu = true;
            
        }
    }
}
