using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public bool isPlayer = false; //Saber qual é o jogador

    private void Update() //Trazer para o menu a pontuação que os jogadores fizeram durante a partida
    {
        if (isPlayer)
        {
            score.text = SaveController.Instance.MaxScorePlayer.ToString();
        }
        else
        {
            score.text = SaveController.Instance.MaxScoreEnemy.ToString();
        }
    }

    public void ResetPoints() //Resetar a pontuação dos jogadores para iniciar uma nova partida
    {
        if (isPlayer)
        {
            SaveController.Instance.MaxScorePlayer = 0;
            score.text = SaveController.Instance.MaxScorePlayer.ToString();
        }
        else
        {
            SaveController.Instance.MaxScoreEnemy = 0;
            score.text = SaveController.Instance.MaxScoreEnemy.ToString();
        }
    }
}
