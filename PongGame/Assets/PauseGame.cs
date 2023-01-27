using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Button button;
    public Sprite playIcon;
    public Sprite pauseIcon;
    public bool isPaused = false;

    public GameObject pauseScreen;
    public void Pause ()
    {
        
        if (isPaused == false)
        {
          Time.timeScale = 0;  
          isPaused = true;
          pauseScreen.SetActive(true);
          button.GetComponent<Image>().sprite = playIcon;
        }else
        {
          Time.timeScale = 1; 
          isPaused = false;
          pauseScreen.SetActive(false);
          button.GetComponent<Image>().sprite = pauseIcon;
        }
        
    }
    
}
