using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour 
{
    public GameObject PausePanel;

    public void Pause()
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        } 

    public void UnPause()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    } 



}