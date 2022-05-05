using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    
    [SerializeField] Slider healthSlider;
    [SerializeField] HealthScript health;
    [SerializeField] TextMeshProUGUI scorefield;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = health.getCurrentHealth();
    }

    private void Update()
    {
        updateUIWithCurrentScore();
        updateHealthInUI();
    }

    private void updateHealthInUI(){
        healthSlider.value = health.getCurrentHealth();
    }

    private void updateUIWithCurrentScore(){
        int currentScore = scoreKeeper.getCurrentScore();
        scorefield.text = currentScore.ToString();
    }


}
