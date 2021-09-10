using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
  public Transform DetectaChao;
  public float distancia = 3;
  public bool olhandoParaDireita;
  public float velocidade= 4;

  public float rondaDistancia = 4000;
  private float ronda = 0;


  void Start()
  {
     olhandoParaDireita=true;
  }

  void Update()
  {
     Patrulha1() ; 
  }

  public void Patrulha1()
  { 
     
     ronda = ronda + 1;

     if (ronda > 0)
     {
      transform.eulerAngles = new Vector3(0, -180, 0);  
      transform.Translate(Vector2.right * velocidade * Time.deltaTime);
     }
     else{
        transform.Translate(Vector2.right * velocidade * Time.deltaTime*-1);
        transform.eulerAngles = new Vector3(0, 180, 0);
      }
      if(ronda*ronda/2>rondaDistancia)
      ronda = ronda * -1;


  }
  public void Patrulha()
  { 
       
   transform.Translate(Vector2.right * velocidade * Time.deltaTime);
   
     RaycastHit2D groundInfo = Physics2D.Raycast(DetectaChao.position, Vector2.down, distancia);
     if (groundInfo.collider == false)
     {
         if (olhandoParaDireita == true)
         {
             transform.eulerAngles = new Vector3(0, 180, 0);
             olhandoParaDireita= false;
         }
         else
         {
                transform.eulerAngles = new Vector3(0, 0, 0);
                olhandoParaDireita = true;
         }
     } 
  }

}