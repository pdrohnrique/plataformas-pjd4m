using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public enum GameState
    {
        Loading,
        MainMenu,
        Playing
    }

    public class GameManager : MonoBehaviour
    {
    
        public static GameManager Instance { get; private set; }
        private GameState _currentState;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    
        void Start()
        {
            SetState(GameState.Loading);
        }

        private void SetState(GameState newState)
        {
            _currentState = newState;
            Debug.Log("Game State: " + _currentState);
        }

        public void LoadScene(string sceneName)
        {
            switch (sceneName)
            {
                case "MainMenu":
                    SetState(GameState.MainMenu);
                    break;
                case "GameScene":
                    SetState(GameState.Playing);
                    StartCoroutine(LoadSceneWithGUI(sceneName));
                    return;
            }
        
            SceneManager.LoadScene(sceneName);
        }

        private IEnumerator LoadSceneWithGUI(string sceneName)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
            yield return op;
            SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
        }
    }
}