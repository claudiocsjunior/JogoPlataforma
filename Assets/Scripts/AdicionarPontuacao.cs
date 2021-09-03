using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionarPontuacao : MonoBehaviour
{
    public int pontuacaoAtribuir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            EstadoPersonagem.Instance.nomesChavesObtidas.Add(this.transform.parent.gameObject.name);
            EstadoPersonagem.Instance.pontuacao += pontuacaoAtribuir;
            Destroy(this.transform.parent.gameObject);
        }
    }
}
