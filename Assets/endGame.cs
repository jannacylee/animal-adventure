using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject EndPanel;
    public Button RestartButton;
    public static EndManager Singleton;

    private void Start()
    {
        Singleton = this;
        Time.timeScale = 0f;
        EndPanel.SetActive(true);
        RestartButton.onClick.AddListener(RestartGame);
        

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

