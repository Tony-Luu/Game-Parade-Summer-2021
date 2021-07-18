using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AM_PauseGame : MonoBehaviour
{
    bool isPaused = false;

    public Image gamePauseImage;
    public Button backToTitleButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                gamePauseImage.gameObject.SetActive(false);
                backToTitleButton.gameObject.SetActive(false);
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gamePauseImage.gameObject.SetActive(true);
                backToTitleButton.gameObject.SetActive(true);
                isPaused = true;
            }
        }
    }
}
