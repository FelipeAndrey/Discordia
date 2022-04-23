using UnityEngine;

public class Barganha : MonoBehaviour
{  //Declaração de Variaveis
    //Variaveis de GameObject (Recebem o gameobject no inspector)
    public GameObject volume1;
    public GameObject volume2;
    //Booleana que fica true, caso a barganha seja aceita
    public bool barganhado;
    private void Update()
    {
        //Chama a função de recuperar visão
        Vernovamente();
    }
    //Função de Visão
    public void Vernovamente() { 
        //Caso o jogador aceite a barganha
        if(barganhado == true)
        {   //Desliga os efeitos Cego
            volume1.SetActive(false);
            //Liga o  Efeito Visão;
            volume2.SetActive(true);
        }
    }
}
