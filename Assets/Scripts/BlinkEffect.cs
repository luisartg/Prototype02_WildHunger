using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public SkinnedMeshRenderer visualReference;

    private bool isBlinking;
    private float blinkTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        visualReference = GetComponent<SkinnedMeshRenderer>();
        isBlinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DoBlink()
    {
        if (isBlinking)
        {
            visualReference.enabled = !visualReference.enabled;
            Invoke(nameof(DoBlink), blinkTime);
        }
    }

    public void StartBlinking()
    {
        isBlinking = true;
        DoBlink();
    }

    public void EndBlinking()
    {
        isBlinking = false;
        visualReference.enabled = true;
    }
}
