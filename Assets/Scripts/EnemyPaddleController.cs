using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    public float speed = 5f; //Velocidade de movimenta��o
    public Vector2 Limits = new Vector2(-4.3f, 4.3f);

    public SpriteRenderer spriteRendererEnemy;
    public SpriteRenderer spriteRendererWall;

    private void Start() //Iniciar com as cores que o Enemy escolheu no menu
    {
        spriteRendererEnemy.color = SaveController.Instance.EnemyColor;
        spriteRendererWall.color = SaveController.Instance.EnemyColor;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 newPosition = transform.position + Vector3.up * speed * Time.deltaTime; //Se movimenta em uma velocidade speed

            newPosition.y = Mathf.Clamp(newPosition.y, Limits.x, Limits.y); //N�o deixa o paddle sair da tela na pos��o Y pr�-Determinada

            transform.position = newPosition; //Muda a posi��o do paddle
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPosition = transform.position + Vector3.down * speed * Time.deltaTime; //Se movimenta em uma velocidade speed

            newPosition.y = Mathf.Clamp(newPosition.y, Limits.x, Limits.y); //N�o deixa o paddle sair da tela na pos��o Y pr�-Determinada

            transform.position = newPosition; //Muda a posi��o do paddle
        }
    }
}
