using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EstadoPersonagem : MonoBehaviour
{
    private static EstadoPersonagem _instance;
    public static EstadoPersonagem Instance { get { return _instance; } }

    public int vidas = 5;
    public int chavesObtidas = 0;
    public int pontuacao = 0;
    public int totalChaves = 5;
    public float tempo = 360f;
    public Text keyText;
    public Text PontuacaoText;
    public Text VidasText;
    public Text TempoText;

    public GameObject portaSaida;

    //public float tempo 
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start()
    {
        portaSaida.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(chavesObtidas == totalChaves){
            portaSaida.SetActive(true);
        }

        keyText.text = chavesObtidas.ToString() + "/" + totalChaves.ToString();
        PontuacaoText.text = pontuacao.ToString();
        VidasText.text = vidas.ToString();

        float tempoTemp = tempo -= Time.deltaTime;

        TempoText.text = tempoTemp.ToString();

        if(vidas <= 0 || tempo <= 0){
            SceneManager.LoadScene("Game Over");
        }

    }
}
