using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public bool isPaused = false;
    public bool isEnded = false;
    private int score = 0;

    public int Score { 
        get { return score; }
        private set { score = value; }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else Instance = this;
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void PauseGame() { 
        isPaused = true;
    }

    public void Resume() { 
        isPaused = false;
    }

    public void Restart() { 
        
    }

    public void EndGame() {
        isEnded = true;
        Time.timeScale = 0f;
    }
}
