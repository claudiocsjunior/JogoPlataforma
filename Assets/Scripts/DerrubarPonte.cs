using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerrubarPonte : MonoBehaviour
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
                transform.position = new Vector3(x: transform.position.x, y: transform.position.y - 0.01f, z: transform.position.z);
            }else{
                transform.position = new Vector3(x: transform.position.x, y: alturaInicial, z: transform.position.z);
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
