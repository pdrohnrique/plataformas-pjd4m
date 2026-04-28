using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetState(GameState.MainMenu);
    }
    
    public void StartGame()
    {
        GameManager.Instance.LoadScene("GameScene");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
