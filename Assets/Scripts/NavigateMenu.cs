using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    public void SwitchLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKey("escape"))  // ���� ������ ������� Esc (Escape)
        {
            Application.Quit();    // ������� ����������
        }
    }
}
