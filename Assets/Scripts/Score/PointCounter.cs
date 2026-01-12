using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointCounter : MonoBehaviour {
    [SerializeField] PointHUD pointHUD;
    [SerializeField] PointHUD pointHUD2;
    public bool GameOver;

    private void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            pointHUD2.HighScore = PlayerPrefs.GetInt("HighScore");
        }
        StartCoroutine (CountPoints ());
    }

    private IEnumerator CountPoints () {
        while (!GameOver) {
            pointHUD.Points += 1;

            if (pointHUD.Points > pointHUD2.HighScore)
            {
                pointHUD2.HighScore = pointHUD.Points;
                PlayerPrefs.SetInt("HighScore", pointHUD2.HighScore);
                
            }

            yield return new WaitForSeconds(0.2F);
        }
    }
}