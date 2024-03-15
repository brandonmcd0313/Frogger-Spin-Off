using UnityEngine;

public class EndSpot : MonoBehaviour
{
    // Public boolean variable to track if the spot is filled
    public bool spotFilled = false;
    public GameObject winLight;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // Get the SpriteRenderer component attached to this object
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure the sprite renderer is disabled at start
        spriteRenderer.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag 'Player'
        if (collision.gameObject.tag == "Player")
        {
            // Enable the sprite renderer
            spriteRenderer.enabled = true;
            Instantiate(winLight, transform.position, Quaternion.identity);
           Invoke("fillSpot", 0.5f);
        }
    }

   void fillSpot()
    {
        spotFilled = true;
    }


}
