using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveEstadoGame : SaveGame
{
    public bool gameSalvo = false;
    public int vidas;
    public int chavesObtidas;
    public int pontuacao;
    public int totalChaves;
    public float tempo;
    public PosicaoPersonsagem posicaoPersonsagem;
    public List<string> nomesChavesObtidas = new List<string>();
    public List<string> nomesPontuadoresObtidos = new List<string>();

    public void saveGame(){
        base.save();
    }

    public SaveEstadoGame loadGame(){
        string content = base.load();
        return JsonUtility.FromJson<SaveEstadoGame>(content);
    }


}
