using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverController : MonoBehaviour
{

    public VisualElement ui;
    public Button playButton;
    public Button quitButton;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        playButton = ui.Q<Button>("Play_Again_Button");
        playButton.clicked += OnPlayButtonClicked;

        quitButton = ui.Q<Button>("Quit_Button");
        quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    private void OnPlayButtonClicked()
    {
        GameManager.levelsWon = 0;
        SceneManager.LoadScene("CEA_TESTING");
    }
}
