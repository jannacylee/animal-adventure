using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartPanel;
    public Button StartButton;
    public static GameManager Singleton;
    AudioSource audioSource;

    private void Start()
    {
        Singleton = this;
        Time.timeScale = 0f;
        StartPanel.SetActive(true);
        StartButton.onClick.AddListener(StartGame);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        StartPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}

