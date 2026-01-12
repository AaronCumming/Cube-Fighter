 using UnityEngine;
 using UnityEngine.SceneManagement;
 using UnityEngine.UI;

 public class SceneController : MonoBehaviour {

    public string sceneName;
 
    public void LoadSceneByName() 
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void CloseGame()
    {
        Application.Quit();
    }
 }