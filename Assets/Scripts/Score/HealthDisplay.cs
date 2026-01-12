using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthText;

    public PlayerHealth scriptHealthRef;

    // Update is called once per frame
    void Update()
    {
        int p_health = scriptHealthRef._currentHP;
        HealthText.text = "Health: " + p_health.ToString();
    }
}
