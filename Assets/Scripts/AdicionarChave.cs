using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionarChave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            EstadoPersonagem.Instance.chavesObtidas++;
            Destroy(this.transform.parent.gameObject);
        }
    }
}
