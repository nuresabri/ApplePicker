using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject startScene;
    public void Begin()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
