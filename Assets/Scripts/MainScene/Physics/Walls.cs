using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    Material material;
    [ColorUsage(true, true)]
    public Color wallColour = Color.red;
    SpriteRenderer spriteRenderer;
    public float intensity;
    float factor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
        factor = Mathf.Pow(2, intensity);
    }

    // Update is called once per frame
    void Update()
    {
        wallColour = Color.Lerp(Color.red * factor, Color.blue * factor, Mathf.PingPong(Time.time, 1f));
        material.color = wallColour;
        spriteRenderer.material = material;
    }
}
