using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogo_BG : MonoBehaviour
{
    public float modificadorVelocidade = 1f;

    public float velocidade = 4.5f;

    public float velocidadeMaxima = 10f;

    private void Update()
    {
        //Aumenta a velocidade ao decorrer do tempo até a velocidadeMaxima
        velocidade = Mathf.Clamp(
            velocidade + modificadorVelocidade * Time.deltaTime,
            0,
            velocidadeMaxima
        );
    }

    

}
