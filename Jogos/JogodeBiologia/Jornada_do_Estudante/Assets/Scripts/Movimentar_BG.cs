using System.Numerics;
using UnityEngine;

public class Movimentar_BG : MonoBehaviour
{
    public UnityEngine.Vector2 direcao;

    private Jogo_BG jogoScript;

    void Start()
    {
        //Procura o Objeto Jogo, pega o Script/Componente Jogo dele e coloca na variável jogoScript
        jogoScript = GameObject.Find("Jogo").GetComponent<Jogo_BG>();
    }


    private void Update()
    {
        //Muda a posição do objeto dependendo da direção e da velocidade
        //Time.deltaTime é utilizado para que o jogo funcione igual em máquinas com framerate diferente
        transform.Translate(direcao * jogoScript.velocidade * Time.deltaTime);
    }
}
