using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GeradorInimigos_BG : MonoBehaviour
{
    public GameObject[] cactoPrefabs;

    public GameObject dinoVoadorPrefab;

    public float dinoVoadorYMin = 0;

    public float dinoVoadorYMax = 2;

    public float pontosMinDinoVoador = 300;

    public float delayInicial;

    public float delayEntreInimigos;

    public float distanciaMinima = 4;

    public float distanciaMaxima = 8;

    public Jogador_BG jogadorScript;

    private void Start()
    {
        //Determinada as características de spawn dos cactos
        //InvokeRepeating("GerarInimigo", delayInicial, delayEntreCactos);
        StartCoroutine(GerarInimigo());
    }

    private IEnumerator GerarInimigo()
    {
        //Espera o delay inicial para começar a gerar inimigos
        yield return new WaitForSeconds(delayInicial);

        GameObject ultimoInimigoGerado = null;

        var distanciaNecessaria = 0f;

        while (true)
        {
            //Só libera a geração de inimigos se não tiver sido gerado nenhum antes ou se atingir
            //a distância necessária
            var geracaoInimigoLiberada =
                ultimoInimigoGerado == null
                || Vector3.Distance(transform.position, ultimoInimigoGerado.transform.position) >= distanciaNecessaria;

            if (geracaoInimigoLiberada)
            {
                //Aleatoriza um valor para gerar inimigos
                var randomizador = Random.Range(1, 4);

                //Só gera Dinossauros Voadores se o Jogador atingir uma pontuação mínima
                if (jogadorScript.pontos >= pontosMinDinoVoador && randomizador <= 1)  //Gerar Dinossauro Voador
                {
                    //Varia o valor Y do Dinossauro Voador
                    var posicaoYAleatoria = Random.Range(dinoVoadorYMin, dinoVoadorYMax);

                    //Determina a posição Y
                    var posicao = new Vector3(
                        transform.position.x,
                        transform.position.y + posicaoYAleatoria,
                        transform.position.z
                    );

                    //Determina qual foi o último inimigo gerado
                    //tranform.position é a posição do gerador; Quaternion.identity define a rotação = 0
                    ultimoInimigoGerado = Instantiate(dinoVoadorPrefab, posicao, Quaternion.identity);
                }

                else  //Gerar Cactos
                {
                    var quantidadeCactos = cactoPrefabs.Length;

                    //Aleatoriza um valor entre as posições do cactoPrefabs; valor final não é incluso
                    var indiceAleatorio = Random.Range(0, quantidadeCactos);

                    //Atribui um valor ao cactoPrefab que vai ser instanciado
                    var cactoPrefab = cactoPrefabs[indiceAleatorio];

                    //Gera o cacto escolhido
                    //Determina qual foi o último inimigo gerado
                    //tranform.position é a posição do gerador; Quaternion.identity define a rotação = 0
                    ultimoInimigoGerado = Instantiate(cactoPrefab, transform.position, Quaternion.identity);
                }

                //Aleatoriza uma distância que um inimigo gerado deve estar para pode gerar outro
                distanciaNecessaria = Random.Range(distanciaMinima, distanciaMaxima);

            }

            yield return null;

        }
    }
}
