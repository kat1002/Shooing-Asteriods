using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance != null) { 
            Destroy(gameObject);
        }
        else Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        scoreText.text = GameController.Instance.Score.ToString();
    }
}
