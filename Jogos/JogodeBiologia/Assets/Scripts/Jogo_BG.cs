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

    public void ReiniciarJogo()
    {
        //Reinicia a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Volta o tempo para a configuração padrão
        Time.timeScale = 1;
    }

}
