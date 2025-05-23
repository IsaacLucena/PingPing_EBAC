using UnityEngine;
using UnityEngine.UI;

public class CrownController : MonoBehaviour
{
    [Header ("Crowns")] //Todas as imagens de coroas de todas as cores
    public Image YellowCrown;
    public Image GreenCrown;
    public Image BlueCrown;
    public Image PinkCrown;

    [Header("Colors")] //Todas as opçoes de cores
    public Color Yellow;
    public Color Green;
    public Color Blue;
    public Color Pink;

    private void Update()
    {
        if (SaveController.Instance.WinnerColor == Color.white) //se não tiver cor definida não mostrar coroa
        {
            AllFalse();
        }
        else //se tiver cor definida procurar qual a cor e mostrar coroa da mesma cor que o ganhador
        {
            UpdateCrown();
        }
    }

    public void UpdateCrown() //Descobrir qual a cor que o ganhador escolheu e ligar a imagem da coroa da cor do ganhador
    {
        
        if (SaveController.Instance.WinnerColor == Yellow)
        {
            YellowCrown.gameObject.SetActive(true);
        }
        else if (SaveController.Instance.WinnerColor == Green)
        {
            GreenCrown.gameObject.SetActive(true);
        }
        else if (SaveController.Instance.WinnerColor == Blue)
        {
            BlueCrown.gameObject.SetActive(true);
        }
        else if (SaveController.Instance.WinnerColor == Pink)
        {
            PinkCrown.gameObject.SetActive(true);
        }
    }

    public void AllFalse() //Desligar todas as imagens quando não tiver ganhador ou não tiver cor escolhida (padrão)
    {
        YellowCrown.gameObject.SetActive(false);
        GreenCrown.gameObject.SetActive(false);
        BlueCrown.gameObject.SetActive(false);
        PinkCrown.gameObject.SetActive(false);
    }
}
