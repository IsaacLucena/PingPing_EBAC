using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startingVelocity = new Vector2(-5f,5f); //Velocidade inicial da bola

    public GameManager gameManager; //pega o código GameManager
    public float SpeedUp = 1.1f;

    public void ResetBall()
    {
        transform.position = Vector3.zero; //Posição inicial da bola 0 nos 3 eixos

        if(rb == null) rb = GetComponent<Rigidbody2D>(); //Se o rigidBody2D for nulo ele pega o componente RigidBody2D
        rb.linearVelocity = startingVelocity; // implementa a startingVelocity na Velocidade do RigidBody2D
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) //se acontecer uma colisão da bola com a Tag "Wall"
        {
            Vector2 newVelocity = rb.linearVelocity; //Armazena a velocidade passada

            newVelocity.y = -newVelocity.y; //implementa no eixo y uma velocidade contrária a que ele tinha
            rb.linearVelocity = newVelocity; //Implementa na velocidade do rigidBody a nova velocidade no eixo y
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) //se a bola bater nos paddles
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y); //muda a velocidade no eixo x e mantém no eixo y
            rb.linearVelocity *= SpeedUp; //Aumenta a velocidade de acordo com as batidas nos paddles
        }

        if (collision.gameObject.CompareTag("PlayerGoal")) //Se a bola bater no PlayerGoal
        {
            gameManager.ScorePlayer(); //Chama a função que aumenta os pontos do player
            ResetBall(); //Reseta a bola
        }
        else if (collision.gameObject.CompareTag("EnemyGoal"))
        {
            gameManager.ScoreEnemy(); //Chama a função que aumenta os pontos do enemy
            ResetBall(); 
        }
    }
}
