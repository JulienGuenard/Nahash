using UnityEngine;

public class TownData : MonoBehaviour
{
    public TownObj townObj;

    private void Start()
    {
        Reveal(false);
    }

    private void Reveal(bool state)
    {
        GetComponent<SpriteRenderer>().enabled = state;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WorldmapSquare")
        {
            Reveal(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Reveal(true);
        }
    }
}
