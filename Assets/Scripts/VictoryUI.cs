using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{

    public void Enable()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {

    }
}
