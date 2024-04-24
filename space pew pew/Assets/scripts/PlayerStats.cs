using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static PlayerStats playerStats;
    int score;
    public int playerLife;
    public int maxlife;

    public Image[] life;
    public Sprite fullLife;
    public Sprite emptyLife;

    private void Awake()
    {
        if (playerStats == null)
        {
            playerStats = this;
        }
        else if (playerStats != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
    }

    public void UpdateScore()
    {
        score += 100;
        string scoreStr = string.Format("{0:000000}", score);
        scoreText.text = "Score: " + scoreStr;
    }
    void UpdateLife()
    {
        if (playerLife > maxlife)
        { 
            playerLife = maxlife;
        }

        for (int i = 0; i < life.Length; i++)
        {
            if (i < playerLife)
            {
                life[i].sprite = fullLife;
            }
            else
            {
                life[i].sprite = emptyLife;
            }

            if (i < maxlife)
            {
                life[i].enabled = true;
            }
            else
            {
                life[i].enabled = false;
            }
        }
    }
}
