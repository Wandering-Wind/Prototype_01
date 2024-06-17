// ButtonManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public TurnManager turnManager;

    public void OnButtonPress()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TutorialScene()
    {
        SceneManager.LoadScene(4);
    }
}
