using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiController : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
