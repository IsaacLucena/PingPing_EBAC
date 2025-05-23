using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneHelper : MonoBehaviour
{
    public void OpenScene(string SceneToOpen) //Classe que abre as cenas quando chamada
    {
        SceneManager.LoadScene(SceneToOpen);
    }
}
