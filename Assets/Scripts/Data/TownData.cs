using UnityEngine;

public class TownData : MonoBehaviour
{
    public TownObj townObj;

    private void Awake()
    {
        Reveal(false);
    }

    private void Reveal(bool state)
    {
        GetComponent<SpriteRenderer>().enabled = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerVision")
        {
            Reveal(true);
        }
    }
}
