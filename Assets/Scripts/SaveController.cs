using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveController : MonoBehaviour
{
    [Header ("Players Colors")]
    public Color PlayerColor = Color.white; //Salvar as cores dos jogadores
    public Color EnemyColor = Color.white;

    public string NamePlayer; //Salvar os nomes dos jogadores
    public string NameEnemy;

    public int MaxScorePlayer = 0; //Salvar o Score de cada jogador
    public int MaxScoreEnemy = 0;

    public string WinnerName; // Salvar o nome e a cor do vencedor
    public Color WinnerColor = Color.white;

    private static SaveController _instance;
    // Propriedades estaticas para poder acessar a instância

    public static SaveController Instance
    {
        get 
        { 
            // Procure a instância na cena
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<SaveController>();

                // Se não encontrar crie uma nova instância
                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }  
            return _instance; 
        }
    }

    private void Awake()
    {
        // Garanta que exista apenas uma instancia do Singleton
        if( _instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? NamePlayer : NameEnemy;
    }

    public void EnemyWinner() //Se o vencedor for o Enemy salvo todos os dados do Enemy
    {
        WinnerName = NameEnemy;
        WinnerColor = EnemyColor;
    }

    public void PlayerWinner() //Se o vencedor for o Player eu salvo todos os dados do Player
    {
        WinnerName = NamePlayer;
        WinnerColor = PlayerColor;
    }
}
