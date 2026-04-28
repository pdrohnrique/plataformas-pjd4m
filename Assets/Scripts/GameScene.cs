using UnityEngine;

public class GameScene : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetState(GameState.Playing);
    }
}
