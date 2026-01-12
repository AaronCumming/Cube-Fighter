using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class PointHUD : MonoBehaviour {
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI highScoreText;

    int points = 0;
    int highscore = 0;

    private void Awake () {
        UpdateHUD ();
        UpdateHUD2 ();
    }

    public int Points {
        get {
            return points;
        }

        set {
            points = value;
            UpdateHUD ();
        }

    }
        public int HighScore {
        get {
            return highscore;
        }

        set {
            highscore = value;
            UpdateHUD2 ();
        }
    }

    private void UpdateHUD () {
        pointText.text =  points.ToString ();
    }

    private void UpdateHUD2 () {
        highScoreText.text =  highscore.ToString ();

    }


}