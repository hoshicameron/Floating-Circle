using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUtility : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MuteToggleBackgroundMusic()
    {
        AudioManager.Instance.ToggleBackgroundMusic();
    }

    public void MuteToggleSoundFx()
    {
        AudioManager.Instance.ToggleSoundFx();
    }

}// Class
