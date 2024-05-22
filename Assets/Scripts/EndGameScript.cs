using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    public Button restartButton;
    public Button exitButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    void Start()
    {
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("IntroScene"); // Load the intro scene
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
