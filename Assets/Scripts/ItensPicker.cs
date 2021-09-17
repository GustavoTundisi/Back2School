using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Bibliotecas
public class ItensPicker : MonoBehaviour { // Nome da Classe

    
    private int Itens; //Conta o numero de moedas
    public Text scoreText; //Pontuação
    public Text liveText; // Vida
    private int live; // barra de vida
    private Image healthbar; // Imagem da barra de vida
    public AudioSource ItensSound; // Som de pegar a  Moeda
    public AudioSource lifeSound; // Som da morte
    public AudioSource faseSound; // Som da Mudança de fase
    
    
    
    private void Start()
    {
        //inicializa variaveis 
        Itens = ScriptController.userPoints;
        scoreText.text = "";
        liveText.text = "";
        live = ScriptController.userLife;
      //  healthbar = GameObject.FindGameObjectWithTag("BarraHp").GetComponent<Image>();
      
    }

    private void Update()
    {
        scoreText.text = "Itens: "+Itens.ToString();
        liveText.text = "Life: "+live.ToString();

      //  UpdateHealthBar();
       //OnTriggerEnter2D();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("item") == true) //Essa condição verifica se o player encostou com um objeto com rotulo Coin
          {
              ItensSound.Play(); //som de pegar moeda
              //GetComponent<AudioSource>().Play();  
              Itens += 1; // Incrementa contador
              Destroy(collision.gameObject); //Peguei a moeda destroi a moeda
              ScriptController.userPoints=Itens;
          }
          if(collision.CompareTag("inimigo") == true)//Essa condição verifica se o player encostou com um objeto com rotulo Fire
          {
              lifeSound.Play(); //Som de dor
              //GetComponent<AudioSource>().Play();  
              live -= 1; //Decrementa a vida
              Destroy(collision.gameObject); //Destroi o fogo
              ScriptController.userLife=live;
              ScriptController.carregaHistoria();
             // UpdateHealthBar();
             if(live == 0)
             {
             Invoke("ReloadLevel", 0f);
             ScriptController.carregaHistoria();
             ScriptController.userLife=live+10;
             ScriptController.userPoints=Itens-Itens;
             }
          }

         

          if(collision.CompareTag("Fase") == true)
          {
             faseSound.Play();
              //SceneManager.LoadScene("fase2");
              //ScriptController.userPoints=coin;
              //ScriptController.userLife=life;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
              
          }
         else if(collision.CompareTag("Fase2") == true)
          {
             faseSound.Play();
              //SceneManager.LoadScene("fase1");
              //ScriptController.userPoints=coin;
              //ScriptController.userLife=life;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
              
          }
    }
    
     void UpdateHealthBar()
    {
        healthbar.fillAmount = live/10;

      //  int BarLife = live * 10;
     // healthbar.rectTransform.sizeDelta = new Vector2(BarLife, 100);

    }
    
  void ReloadLevel()
  {
    SceneManager.LoadScene("Fase1");

  
  }

}