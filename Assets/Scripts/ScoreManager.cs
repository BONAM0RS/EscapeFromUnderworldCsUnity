using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (PlayerController.Instance.health > 0)
            {
                score++;
                Debug.Log(score);

                ControllerUI.Instance.UpdateScoreDisplay(score);
            }
        }
    }
}
