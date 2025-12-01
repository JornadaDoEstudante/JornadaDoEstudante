using UnityEngine;

public class Chao_BG : MonoBehaviour
{
    //Diferença na posição X entre os chãos
    public float diferencaX;

    //Valor em que o chão sai da Cena
    public float minimoX;

    private void Update()
    {
        //Verifica se o chão saiu da cena
        if (transform.position.x <=minimoX)
        {
            //Modifica a posição x do chão para que ele fique depois do próximo chão
            transform.position = new Vector3(
                transform.position.x + diferencaX * 2, transform.position.y, transform.position.z
            );
        }

    }
}
