using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPontuacaoFinal : MonoBehaviour
{
    
    public Text pontuacao;

    void Start()
    {
        pontuacao.text = "Pontuação:" + PlayerPrefs.GetString("Pontuacao"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
