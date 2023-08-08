using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public int keyPressInterval = 1;

    private float remainingKeyTime = 0;

    // Update is called once per frame
    void Update()
    {

        if (IsKeyEnabled())
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                remainingKeyTime = keyPressInterval;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }
    }

    private bool IsKeyEnabled()
    {
        remainingKeyTime -= Time.deltaTime;
        if (remainingKeyTime <= 0)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
}
