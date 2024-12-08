using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject StartPanel;
    public Button StartButton;
    public Button InstructionButton;
    public Button BackButton;

    public GameObject InstructionPanel;
    public static StartManager Singleton;
    AudioSource audioSource;

    private void Start()
    {
        Singleton = this;
        Time.timeScale = 0f;
        StartPanel.SetActive(true);
        InstructionPanel.SetActive(false);
        StartButton.onClick.AddListener(StartGame);
        InstructionButton.onClick.AddListener(OpenInstructions);
        BackButton.onClick.AddListener(GoBack);

    }

    public void OpenInstructions()
    {
        StartPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }
    public void GoBack()
    {
        StartPanel.SetActive(true);
        InstructionPanel.SetActive(false);
    }
    public void StartGame()
    {
        StartPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}

