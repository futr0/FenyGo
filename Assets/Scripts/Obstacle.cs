using System.Collections;
using System.Collections.Generic;
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
            Instantiate(effect, transform.position, Quaternion.identity);

            if (other.GetComponent<Player>().health > 0)
            {
                other.GetComponent<Player>().health -= CalculateDamage();
            }
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }

    private float CalculateDamage()
    {
        return grams / maxGrams;
    }
}
