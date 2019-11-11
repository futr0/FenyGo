using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float grams;
    public float maxGrams;
    public float speed;
    public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                Instantiate(effect, transform.position, Quaternion.identity);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            if (other.GetComponent<Player>().wphe < other.GetComponent<Player>().targetWphe)
            {
                other.GetComponent<Player>().wphe += CalculateWpheIncrement();
                other.GetComponent<Player>().points += 1;
            }
            Destroy(gameObject);
        }
    }

    private float CalculateWpheIncrement()
    {
        return grams / maxGrams;
    }
}
