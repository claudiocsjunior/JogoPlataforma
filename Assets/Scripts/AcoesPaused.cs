using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcoesPaused : MonoBehaviour
{
    public CharacterController controller;

    public void voltarAoJogo(){
        EstadoPersonagem.Instance.PausarJogo();    
    }

    public void salvar(){
        SaveEstadoGame saveEstadoGame = new SaveEstadoGame(){
            chavesObtidas = EstadoPersonagem.Instance.chavesObtidas,
            pontuacao = EstadoPersonagem.Instance.pontuacao,
            tempo = EstadoPersonagem.Instance.tempo,
            totalChaves = EstadoPersonagem.Instance.totalChaves,
            vidas = EstadoPersonagem.Instance.vidas,
            nomesChavesObtidas = EstadoPersonagem.Instance.nomesChavesObtidas,
            nomesPontuadoresObtidos = EstadoPersonagem.Instance.nomesPontuadoresObtidos,
            gameSalvo = true,
            posicaoPersonsagem = new PosicaoPersonsagem(){
                x = controller.transform.position.x,
                y = controller.transform.position.y,
                z = controller.transform.position.z,
            },
        };

        saveEstadoGame.saveGame();
    }


}
