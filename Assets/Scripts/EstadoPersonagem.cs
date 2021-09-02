using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EstadoPersonagem : MonoBehaviour
{
    private static EstadoPersonagem _instance;
    public bool pausado;
    public static EstadoPersonagem Instance { get { return _instance; } }

    public CharacterController controller;
    public int vidas = 5;
    public int chavesObtidas = 0;
    public int pontuacao = 0;
    public int totalChaves = 5;
    public float tempo = 300f;
    public Text keyText;
    public Text PontuacaoText;
    public Text VidasText;
    public Text TempoText;
    public GameObject PausePainel;
    private bool carregarJogo;

    public List<string> nomesChavesObtidas = new List<string>();

    private SaveEstadoGame saveEstadoGame = new SaveEstadoGame();

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
        pausado = false;
        Time.timeScale = 1f;
        portaSaida.SetActive(false);
        carregarJogo = PlayerPrefs.GetInt("CarregarJogo") > 0 ? true : false; 

        if(carregarJogo){
            executarCarregamentoJogo();
        }else{
            saveEstadoGame.limparSlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            PausarJogo();
        }


        if(chavesObtidas == totalChaves){
            portaSaida.SetActive(true);
        }

        keyText.text = chavesObtidas.ToString() + "/" + totalChaves.ToString();
        PontuacaoText.text = pontuacao.ToString();
        VidasText.text = vidas.ToString();

        float tempoTemp = tempo -= Time.deltaTime;


        TimeSpan time = TimeSpan.FromSeconds(tempoTemp);

        //here backslash is must to tell that colon is
        //not the part of format, it just a character that we want in output
        string str = time.ToString(@"mm\:ss");

        TempoText.text = str;

        if(vidas <= 0 || tempo <= 0){
            SceneManager.LoadScene("Game Over");
        }

    }


    public void PausarJogo(){
        if(pausado){
            pausado = false;
            Time.timeScale = 1f;
            PausePainel.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }else{
            pausado = true;
            Time.timeScale = 0f;
            PausePainel.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }

    void executarCarregamentoJogo(){
        
        saveEstadoGame = saveEstadoGame.loadGame();

        chavesObtidas = saveEstadoGame.chavesObtidas;
        pontuacao = saveEstadoGame.pontuacao;
        tempo = saveEstadoGame.tempo;
        totalChaves = saveEstadoGame.totalChaves;
        vidas = saveEstadoGame.vidas;
        nomesChavesObtidas = saveEstadoGame.nomesChavesObtidas;

        controller.enabled = false;
        controller.transform.position = new Vector3(
            (float)saveEstadoGame.posicaoPersonsagem.x, 
            (float)saveEstadoGame.posicaoPersonsagem.y, 
            (float)saveEstadoGame.posicaoPersonsagem.z
            );
        controller.enabled = true;

        inativarChaves();
    }

    void inativarChaves(){
        foreach(string chave in nomesChavesObtidas){
            GameObject chaveObject = GameObject.Find(chave);
            chaveObject.SetActive(false);
        }
    }
}
