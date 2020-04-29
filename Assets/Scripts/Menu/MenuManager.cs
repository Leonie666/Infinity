using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Object mainMenuObject;

    [SerializeField] private Object pauseMenuObject;

    [SerializeField] private Object volumeSettingsObject;

    private int menuState;

    // Start is called before the first frame update
    void Start()
    {
        menuState = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEscape();
    }

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
                    menuState = 1;
                    break;
                case 3:
                    break;
            }
        }
    }

    public void StartGame()
    {
        Destroy(mainMenuObject);
        Time.timeScale = 1;
        menuState = 0;
    }

    private void OpenPauseMenu()
    {
        Instantiate(pauseMenuObject);
        Time.timeScale = 0;
        menuState = 1;
    }

    public void ResumeGame()
    {
        Destroy(pauseMenuObject);
        Time.timeScale = 1;
        menuState = 0;
    }

    public void RestartGame()
    {
        Instantiate(mainMenuObject);
        menuState = 3;
    }

    public void OpenVolumeSettings()
    {
        Destroy(pauseMenuObject);
        Instantiate(volumeSettingsObject);
        menuState = 2;
    }

    public void HandleVolumeSettings()
    {

    }

    public void CloseVolumeSettings()
    {
        Destroy(volumeSettingsObject);
        Instantiate(pauseMenuObject);
        menuState = 1;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
