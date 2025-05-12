using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string scene;

    public void SceneSwitch()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
