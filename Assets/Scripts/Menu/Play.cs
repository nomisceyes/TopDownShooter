using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void InGame()
    {
        SceneManager.LoadScene("Game");
    }
}