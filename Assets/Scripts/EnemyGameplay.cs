using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGameplay : MonoBehaviour
{
    public PlayerGameplay playerRef;
    public int scoreValue = 1;
    private Slider lifeBar;
    private float destroyTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<PlayerGameplay>();
        lifeBar = gameObject.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            playerRef.DecreaseLives();
        }
        else 
        {
            AddDamage();
        }
    }

    private void DestroyEnemy()
    {
        if (playerRef != null)
        {
            playerRef.IncreaseScore(scoreValue);
        }
        Destroy(gameObject);
    }

    private void AddDamage()
    {
        lifeBar.value++;
        if (lifeBar.value == lifeBar.maxValue)
        {
            Invoke(nameof(DestroyEnemy), destroyTime);
        }
    }
}
