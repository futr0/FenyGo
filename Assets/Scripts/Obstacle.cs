using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            Instantiate(effect, transform.position, Quaternion.identity);

            if (other.GetComponent<Player>().wphe < other.GetComponent<Player>().targetWphe)
            {
                other.GetComponent<Player>().wphe += CalculateWpheIncrement();
                other.GetComponent<Player>().points += 1;
            }
            //Debug.Log(other.GetComponent<Player>().wphe);
            Destroy(gameObject);
        }
    }

    private float CalculateWpheIncrement()
    {
        return grams / maxGrams;
    }
}
