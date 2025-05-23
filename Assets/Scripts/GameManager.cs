using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Transformers")]
    public Transform playerPaddle; //Pega a posição do PlayerPaddle
    public Transform enemyPaddle; //Pega a posição do EnemyPaddle

    [Header("Controller")]
    public BallController ballController; //Pega o código BallController
    public OpenSceneHelper openSceneHelper;
    public string gameOverScene = "GameOver";

    [Header("StartingPositions")]
    public Vector3 StartingPositionPlayer = new Vector3(8f,0f,0f); //Posição inicial dos paddles
    public Vector3 StartingPositionEnemy = new Vector3(-8f, 0f, 0f);

    [Header("Scores")]
    public int playerScore = 0; //Placar inicial 0
    public int enemyScore = 0;

    [Header ("TextMashPro")]
    public TextMeshProUGUI textPointsPlayer; //Pega o TextMeshPro que implementamos na cena para poder altera-lo com código
    public TextMeshProUGUI textPointsEnemy;

    [Header("WinPoints")]
    public int WinPoints = 2; //Pontuação para ganhar
    
    void Start()
    {
        ResetGame(); //Chama a função para resetar a cena sempre que o start é chamado
    }

    public void ResetGame()
    {
        playerPaddle.position = StartingPositionPlayer; //Posição inicial do PlayerPaddle
        enemyPaddle.position = StartingPositionEnemy; //Posição inicial do EnemyPaddle

        ballController.ResetBall(); //Chama a função "ResetBall" do código "ballController"

        playerScore = 0; 
        enemyScore = 0; //Reseta a contagem dos pontos

        textPointsPlayer.text = playerScore.ToString(); 
        textPointsEnemy.text = enemyScore.ToString(); //Reseta os pontos no TextMeshPro
    }

    public void ScorePlayer() //Conta mais um no placar do player quando ele fizer ponto
    {
        playerScore++; 
        textPointsPlayer.text = playerScore.ToString();
        SaveController.Instance.MaxScorePlayer++;
        CheckWin();
    }

    public void ScoreEnemy() //Conta mais um no placar do enemy quando ele fizer ponto
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        SaveController.Instance.MaxScoreEnemy++;
        CheckWin();
    }

    private void CheckWin() //Sempre Que fizer ponto checa se alguém ganhou
    {
        if(enemyScore >= WinPoints || playerScore >= WinPoints)//Da o Nome e a cor do player que ganhou a partida
        {
            if (enemyScore >= WinPoints)
            {
                SaveController.Instance.EnemyWinner();
                openSceneHelper.OpenScene(gameOverScene);
            }
            else
            {
                SaveController.Instance.PlayerWinner();
                openSceneHelper.OpenScene(gameOverScene);
            }
        }
    }
}