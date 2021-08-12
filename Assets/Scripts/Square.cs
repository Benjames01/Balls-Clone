using System;
using TMPro;
using UnityEngine;

public class Square : MonoBehaviour
{

    int hitsRemaining = 6;

    SpriteRenderer spriteRenderer;
    TextMeshPro textMesh;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMesh = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    void UpdateVisualState()
    {
        textMesh.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.green, Color.red, hitsRemaining / 10f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        hitsRemaining--;
        if(hitsRemaining > 0)
         {
            UpdateVisualState();
        }else
        {
            Destroy(gameObject);
        }
    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }
}
