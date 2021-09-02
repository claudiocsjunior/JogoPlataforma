using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject botaoCarregarJogo = GameObject.Find("BotaoCarregarJogo");

        SaveEstadoGame saveEstadoGame = new SaveEstadoGame();
        saveEstadoGame = saveEstadoGame.loadGame();

        if(saveEstadoGame != null){
            botaoCarregarJogo.SetActive(true);
        }else{
            botaoCarregarJogo.SetActive(false);
        }
    }

}
