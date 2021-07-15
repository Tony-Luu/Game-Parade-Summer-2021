using UnityEngine;
using UnityEngine.SceneManagement;

public class AM_MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOptions()
    {

    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
