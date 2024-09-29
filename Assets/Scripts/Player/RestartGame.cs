using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void ReStart()
    {
        SceneManager.LoadScene("Game");
    }
}