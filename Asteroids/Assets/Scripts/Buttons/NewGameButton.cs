using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void StartNewGame()
    {
        Time.timeScale = 1f;
        Game.state = GameState.AlreadyPlaying;
        Score.Reset();
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
