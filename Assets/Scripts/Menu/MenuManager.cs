using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    /// <summary>
    /// prefab of the pause menu
    /// </summary>
    [SerializeField] private GameObject pauseMenuObject;

    /// <summary>
    /// prefab of the volume settings menu
    /// </summary>
    [SerializeField] private GameObject volumeSettingsObject;

    /// <summary>
    /// int to manage actions when escape key is pressed
    /// </summary>
    private int menuState;

    /// <summary>
    /// sets menuState to 3 before the first frame update (because first scene loaded is main menu scene)
    /// </summary>
    void Start()
    {
        menuState = 0;
    }

    /// <summary>
    /// inits CheckEscape() once per frame
    /// </summary>
    void Update()
    {
        CheckEscape();
    }

    /// <summary>
    /// checks if escape key is pressed and opens or closes menu depending on menu state
    /// </summary>
    private void CheckEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (menuState)
            {
                case 0:
                    OpenPauseMenu();
                    break;
                case 1:
                    ResumeGame();
                    break;
                case 2:
                    CloseVolumeSettings();
                    break;
            }
        }
    }

    /// <summary>
    /// starts game by loading game scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        menuState = 0;
    }

    /// <summary>
    /// opens async scene pause menu
    /// </summary>
    private void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0;
        menuState = 1;
    }

    /// <summary>
    /// resumes to the game by closing async scene pause menu
    /// </summary>
    public void ResumeGame()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        menuState = 0;
    }

    /// <summary>
    /// restarts the game by loading main menu scene
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        menuState = 3;
    }

    /// <summary>
    /// opens volume settings, closes pause menu
    /// </summary>
    public void OpenVolumeSettings()
    {
        pauseMenuObject.SetActive(false);
        volumeSettingsObject.SetActive(true);
        menuState = 2;
    }

    /// <summary>
    /// handles volume settings
    /// !!NEEDS TO BE COMPLETED!!
    /// </summary>
    public void HandleVolumeSettings()
    {

    }

    /// <summary>
    /// closes volume settings and opens the pause menu
    /// </summary>
    public void CloseVolumeSettings()
    {
        volumeSettingsObject.SetActive(false);
        pauseMenuObject.SetActive(true);
        menuState = 1;
    }

    /// <summary>
    /// stops playing mode if we are in the editor, stops the application if we are using a builded version
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
