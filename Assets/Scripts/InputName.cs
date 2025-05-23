using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InputName : MonoBehaviour
{
    public bool isplayer;
    public TMP_InputField inputFied;

    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        ResetNames();
        //Sempre deixar igual ao SaveController
        
        inputFied.onValueChanged.AddListener(UpdateName); //Sempre que digitar no inputFied dar um UpdateName
    }

    public void UpdateName(string name)
    {
        if (isplayer)//Saber onde salvar o nome
        {
            SaveController.Instance.NamePlayer = name; //Salvar o nome no SaveController
            textMeshPro.text = name; //Escrever o nome digitado na tela
        }
        else
        {
            SaveController.Instance.NameEnemy = name;
            textMeshPro.text = name;
        }
    }

    public void ResetNames()//Sempre deixar padronizado igual ao SaveController
    {
        if (isplayer)//Saber onde salvar o nome
        {
            textMeshPro.text = SaveController.Instance.NamePlayer;
        }
        else
        {
            textMeshPro.text = SaveController.Instance.NameEnemy;
        }
    }
}
