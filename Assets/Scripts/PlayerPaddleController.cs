using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 5f; //Velocidade de movimentação
    public Vector2 Limits = new Vector2(-4.3f, 4.3f); //Limite do espaço que pode percorrer

    public SpriteRenderer spriteRendererPlayer;
    public SpriteRenderer spriteRendererWall;

    private void Start() //Iniciar tanto o paddle quanto o gol da cor que o Player escolheu no menu
    {
        spriteRendererPlayer.color = SaveController.Instance.PlayerColor;
        spriteRendererWall.color = SaveController.Instance.PlayerColor;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 newPosition = transform.position + Vector3.up * speed * Time.deltaTime; //Se movimenta em uma velocidade speed

            newPosition.y = Mathf.Clamp(newPosition.y, Limits.x, Limits.y); //Não deixa o paddle sair da tela na posção Y pré-Determinada

            transform.position = newPosition; //Muda a posição do paddle
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position + Vector3.down * speed * Time.deltaTime; //Se movimenta em uma velocidade speed

            newPosition.y = Mathf.Clamp(newPosition.y, Limits.x, Limits.y); //Não deixa o paddle sair da tela na posção Y pré-Determinada

            transform.position = newPosition; //Muda a posição do paddle
        }
    }
}
