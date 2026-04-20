using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject SettingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsButton()
    {
        SettingsWindow.SetActive(true);
    }

    private void Update()
    {
       
        if (SettingsWindow.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsWindow.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

} 
