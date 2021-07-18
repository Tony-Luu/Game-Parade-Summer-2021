using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AM_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
