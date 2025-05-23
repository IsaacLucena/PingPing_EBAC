using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;

    public void Start()
    {
        ResetColors(); //Sempre que Startado atualizar a cor com a cor do SaveController
    }

    public void OnButtonClick() //Trocar as cores de acordo com as cores do button
    {
        paddleReference.color = uiButton.colors.normalColor; //pega a cor normal do button que foi clicado e coloca no paddle

        if (isColorPlayer) //Saber de quem é a cor que será salva
        {
            SaveController.Instance.PlayerColor = paddleReference.color; //Salva a cor do paddle no jogador
        }
        else
        {
            SaveController.Instance.EnemyColor = paddleReference.color;
        }
    }

    public void ResetColors()//Sempre atualizar as cores com as cores do SaveController
    {
        if (isColorPlayer) //saber de quem é a cor será salva
        {
            paddleReference.color = SaveController.Instance.PlayerColor;
        }
        else
        {
            paddleReference.color = SaveController.Instance.EnemyColor;
        }
    }
}
