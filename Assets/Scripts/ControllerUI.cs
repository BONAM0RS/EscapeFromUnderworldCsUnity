using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    public Text scoreText;

    public Image heart_1;
    public Image heart_2;
    public Image heart_3;

    public GameObject gameOver;

    private static ControllerUI instance;
    public static ControllerUI Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ControllerUI>();
            }
            return instance;
        }
    }

    public void RemoveHeart(int health)
    {
        if (health == 2)
        {
            heart_3.enabled = false;
        }
        else if (health == 1)
        {
            heart_2.enabled = false;
        }
        else if (health == 0)
        {
            heart_1.enabled = false;
        }
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
}
