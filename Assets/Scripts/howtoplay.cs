using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howtoplay : MonoBehaviour
{
    // Speed at which the sprite moves
    public float moveSpeed = 5f;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Move the sprite to the right
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public void ChangeSprite(Sprite newSprite)
    {
        // Change the current sprite to a new one
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
