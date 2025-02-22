using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public VisualElement mainMenuUI;
    public Button playButton;
    //public Button settingsButton;
    public Button quitButton;

    private void Awake()
    {
        mainMenuUI = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        playButton = mainMenuUI.Q<Button>("Play_Button");
        playButton.clicked += OnPlayButtonClicked;

        //settingsButton = mainMenuUI.Q<Button>("Controls_Button");
        //settingsButton.clicked += OnSettingsButtonClicked;

        quitButton = mainMenuUI.Q<Button>("Quit_Button");
        quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    private void OnSettingsButtonClicked()
    {
        Debug.Log("Settings");
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("CEA_TESTING");
    }
}
