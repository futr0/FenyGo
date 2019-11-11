using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Variables
    public float grams;
    public float maxGrams;
    public float speed;
    public GameObject effect;
    #endregion

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayObstacleEffect();
            if (other.GetComponent<Player>().wphe < other.GetComponent<Player>().targetWphe)
            {
                IncrementPlayerStats(other);
            }
            Destroy(gameObject);
        }
    }

    private float CalculateWpheIncrement()
    {
        return grams / maxGrams;
    }

    private void IncrementPlayerStats(Collider2D other)
    {
        other.GetComponent<Player>().wphe += CalculateWpheIncrement();
        other.GetComponent<Player>().points += 1;
    }

    private void PlayObstacleEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
