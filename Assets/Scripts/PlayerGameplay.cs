using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGameplay : MonoBehaviour
{
    public int lives = 3;
    public GameObject messageBoardContainer;

    private TextMeshProUGUI messageBoard;

    private int score = 0;

    //private BoxCollider collider;
    private BlinkEffect blinkEffect;
    private float effectTime = 2;
    private GameReset gameResetRef;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //collider = GetComponent<BoxCollider>();
        gameResetRef = FindObjectOfType<GameReset>();
        blinkEffect = GetComponentInChildren<BlinkEffect>();
        messageBoard = messageBoardContainer.GetComponent<TextMeshProUGUI>();

        WriteMessage("Feed the wild animals with pizza!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int scoreValue)
    {
        if (lives > 0)
        {
            score += scoreValue;
            UpdateInfo();
        }
    }

    private void StartDamageEffect() 
    {
        GetComponent<Collider>().enabled = false;
        blinkEffect.StartBlinking();
        Invoke(nameof(EndDamageEffect), effectTime);
    }

    private void EndDamageEffect()
    {
        GetComponent<Collider>().enabled = true;
        blinkEffect.EndBlinking();
    }

    private void WriteMessage(string message)
    {
        Debug.Log(message);
        messageBoard.text = message;
    }

    public void DecreaseLives()
    {
        lives--;
        UpdateInfo();
        if (lives <= 0)
        {
            gameResetRef.ActiveGameOver();
            Destroy(gameObject);
        }
        else
        {
            StartDamageEffect();
        }
    }

    public void UpdateInfo()
    {
        string gameOverText = "";
        string fullText;
        if (lives <= 0)
        {
            gameOverText = "GAME OVER! (Press Space to try again) - - - ";
        }
        fullText = $"{gameOverText}Lives: {lives} - Score: {score}";
        WriteMessage(fullText);
    }

}
