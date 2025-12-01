using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Jogador_BG : MonoBehaviour
{
    //Chama o RigidBody2D da Unity
    public Rigidbody2D rb;

    //Cria uma variável para definir a intensidade do pulo
    public float forcaPulo;

    //Cria uma variável para definir a intensidade da descida rápida
    public float forcaDescidaRapida;

    //Chama a LayerMask do chão
    public LayerMask layerChao;

    //Cria uma variável para medir a distância mínima para considerar que não está mais no chão
    public float distanciaMinimaChao = 1f;

    //Cria uma variável para definir se está no chão ou não
    private bool estaNoChao;

    public float pontos;

    public float multiplicadorPontos;

    public Text pontosText;

    //Cria uma variável que define o componente de animação ativo
    public Animator animatorCompoment;

    public GameObject BotaoReiniciar;

    void Update()
    {
        //Aumenta a pontuação ao decorrer do tempo
        pontos += Time.deltaTime * multiplicadorPontos;

        //Converte a pontuação arredondada para String
        pontosText.text = $"Pontos: {Mathf.FloorToInt(pontos)}";

        //Executa o método Pular() caso a seta para cima seja apertada nesse frame
        /*if (pular.WasPressedThisFrame())
        {
            Pular();
        }

        //Executa o método Abaixar() caso a seta para baixo seja apertada nesse frame
        if (abaixar.IsPressed())
        {
            Abaixar();
        }

        //Executa o método Levantar() caso a ação abaixar deixe de ser realizada nesse frame
        if (abaixar.WasReleasedThisFrame())
        {
            Levantar();
        }*/
    }

    //Metódo que será executado caso a AcaoPular do InputSystem aconteça
    public void OnPular(InputAction.CallbackContext context)
    {
        if (context.performed && estaNoChao)
        {
            //Cria a força de pulo para cima dependendo do valor da forçaPulo
            rb.AddForce(Vector2.up * forcaPulo);
        }
    }

    //Metódo que será executado caso a AcaoAbaixar do InputSystem aconteça
    public void OnAbaixar(InputAction.CallbackContext context)
    {
        //Ativa se a AcaoAbaixar aconteceu nesse frame
        if (context.performed)
        {
            //Ativa o estado abaixado na animação
            animatorCompoment.SetBool("Abaixado", true);

            //Se não está no chão, cria a força da descida rápida dependendo do valor da forçaDescidaRapida
            if (estaNoChao == false)
            {
                rb.AddForce(Vector2.down * forcaDescidaRapida);
            }
        }
    }

    //Metódo que será executado caso a AcaoAbaixar do InputSystem aconteça
    public void OnLevantar(InputAction.CallbackContext context)
    {
        //Ativa se a acaoAbaixar parou de ser realizada nesse frame
        if (context.canceled)
        {
            //Ativa o estado levantado da animação
            animatorCompoment.SetBool("Abaixado", false);
        }
    }

    void FixedUpdate()
    {
        //Atribue um valor booleano para a variável por meio de um Raycast
        //Raycast cria um raio para medir a distância a determinado objeto
        //(posição inicial, direção, distância p/ verdadeiro, layer de referência)
        estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaMinimaChao, layerChao);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Estabelece a condição de derrota
        if (other.gameObject.CompareTag("Inimigo"))
        {
            //Ativa o Botão de Reiniciar
            BotaoReiniciar.SetActive(true);

            //Congela o jogo
            Time.timeScale = 0;
        }
    }
}
