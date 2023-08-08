using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float upBound = 30;
    public float downBound = -30;
    public float leftBound = -30;
    public float rightBound = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfOutOfBounds(transform.position.x, upBound, downBound);
        DestroyIfOutOfBounds(transform.position.z, rightBound, leftBound);
    }

    void DestroyIfOutOfBounds(float axisPosition, float topBound, float lowerBound)
    {
        if (axisPosition > topBound)
        {
            gameObject.SetActive(false);
        }
        else if (axisPosition < lowerBound)
        {
            gameObject.SetActive(false);
        }
    }
}
