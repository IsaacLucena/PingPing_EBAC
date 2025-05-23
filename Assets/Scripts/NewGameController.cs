using UnityEngine;

public class NewGameController : MonoBehaviour
{
    public InputName inputNamePlayer;
    public InputName inputNameEnemy;
    public ColorSelectionButton colorPlayer;
    public ColorSelectionButton colorEnemy;

    public void DeleteSave() //Deletar todas as informações tanto da tela quanto do SaveController
    {
        SaveController.Instance.NamePlayer = "";
        SaveController.Instance.NameEnemy = "";
        SaveController.Instance.MaxScorePlayer = 0;
        SaveController.Instance.MaxScoreEnemy = 0;
        SaveController.Instance.WinnerName = "";
        SaveController.Instance.WinnerColor = Color.white;
        SaveController.Instance.PlayerColor = Color.white;
        SaveController.Instance.EnemyColor = Color.white;
        //Resetar no SaveController

        inputNameEnemy.ResetNames();
        inputNamePlayer.ResetNames();
        colorPlayer.ResetColors();
        colorEnemy.ResetColors();
        //Resetar no jogo
    }
}
