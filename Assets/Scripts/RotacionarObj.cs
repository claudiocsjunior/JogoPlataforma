using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionarObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!EstadoPersonagem.Instance.pausado){
            transform.Rotate(new Vector3(x: 0, y: 0.4f, z:0));
        }
    }
}
