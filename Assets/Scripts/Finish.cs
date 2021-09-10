using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            //Modificar Scene caso esteja na scene 1, se não modificar para a scene de finalização
            if(EstadoPersonagem.Instance.chavesObtidas == EstadoPersonagem.Instance.totalChaves){
                PlayerPrefs.SetString("Pontuacao", EstadoPersonagem.Instance.pontuacao.ToString());
                SceneManager.LoadScene("Congratulations");
                EstadoPersonagem.Instance.limparGameSaved();
            }
        }
    }

}
