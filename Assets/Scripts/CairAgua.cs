using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CairAgua : MonoBehaviour
{
    public CharacterController controller;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            EstadoPersonagem.Instance.vidas--;
            // GameObject personagem = GameObject.FindGameObjectWithTag("Player");
            
            // print(personagem);
            controller.enabled = false;
            controller.transform.position = new Vector3(-46.41f, 2.31f, 46.25f);
            controller.enabled = true;
            // personagem.transform.position = new Vector3(-46.41f, 2.31f, 46.25f);

            // personagem.transform.GetChild(0).transform.position = new Vector3(-46.41f, 2.31f, 46.25f);
            // personagem.transform.GetChild(1).transform.position = new Vector3(-46.41f, 2.24f, 46.25f);

        }
    }

}
