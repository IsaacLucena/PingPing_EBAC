using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("WinnersName")]
    public TextMeshProUGUI winnersName;

    public OpenSceneHelper openSceneHelper;

    public string menuScene = "Menu"; //Escolher a cena do menu

    private void Update()
    {
        winnersName.text = SaveController.Instance.WinnerName.ToString(); //Colocar na tela o nome do ganhador que está salvo no SaveController
        winnersName.color = SaveController.Instance.WinnerColor; //Trocar a cor do nome do ganhador para a cor que ele escolheu na partida

        Invoke("LoadMenu", 2f); //Abrir o menu depois de 2 segundos
    }

    public void LoadMenu() //Abrir a scene (Menu)
    {
        openSceneHelper.OpenScene(menuScene);
    }
}
