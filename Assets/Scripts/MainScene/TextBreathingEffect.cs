using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBreathingEffect : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public float animationSpeed = 2;
    void Update()
    {
        if(text.alpha == 0)
        {
            text.alpha = Mathf.Lerp(text.alpha, 255, animationSpeed * Time.deltaTime);
        }
        if(text.alpha == 255)
        {
            text.alpha = Mathf.Lerp(text.alpha, 0, animationSpeed * Time.deltaTime);
        }
    }
}
