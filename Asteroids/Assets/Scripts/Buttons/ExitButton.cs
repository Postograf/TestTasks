using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
