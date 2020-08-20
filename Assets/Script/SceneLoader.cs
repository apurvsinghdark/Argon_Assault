using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadMainScene", 2f);
    }
    void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
