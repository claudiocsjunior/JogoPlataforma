using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcoesIniciarJogo : MonoBehaviour
{
    public string scene;
    public void NovoJogo(){
        PlayerPrefs.SetInt("CarregarJogo", 0);
        SceneManager.LoadScene(scene);
    }

    public void CarregarJogo(){
        PlayerPrefs.SetInt("CarregarJogo", 1);
        SceneManager.LoadScene(scene);
    }
}
