using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AM_BackToTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Timer());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "End Screen")
        {
            LoadTitleScreen();
        }
    }

    IEnumerator Timer()
    {
        if(SceneManager.GetActiveScene().name == "End Screen")
        {
            yield return new WaitForSeconds(10.0f);
            LoadTitleScreen();
        }
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
