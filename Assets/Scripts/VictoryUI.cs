using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{

    [SerializeField] private SFXManager sfxManager;

    public void Enable()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        sfxManager.PlayVolcanoSelectSFX();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public void BackToMainMenu()
    {
        sfxManager.PlayVolcanoSelectSFX();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        sfxManager.PlayVolcanoSelectSFX();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
