using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private new Renderer renderer;
    private SpriteRenderer spriteRenderer;
    private Color start;
    private Color end;
    private float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        start = spriteRenderer.color;
        end = new Color(start.r, start.b, start.g, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        renderer.material.color = Color.Lerp(start, end, t / 2);

        if (renderer.material.color.a <= 0.0) { Destroy(this.gameObject); }
    }
}
