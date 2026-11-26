using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private SFXManager sfxManager;
    public void PlayGame()
    {
        sfxManager.PlayVolcanoSelectSFX();
        SceneManager.LoadScene("Gameplay");
    }
}
