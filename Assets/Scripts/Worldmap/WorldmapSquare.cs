using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapSquare : MonoBehaviour
{
    private void Reveal(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerVision")
        {
            Reveal(collision);
        }
    }
}
