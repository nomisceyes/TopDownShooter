using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static bool IsPaused = false;

    [SerializeField] private GameObject _pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        IsPaused = false;
    }

    private void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        IsPaused = true;
    }
}