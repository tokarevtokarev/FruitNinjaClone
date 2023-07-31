using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float explosionForce = 5;
    // mit dieser Methode können wir unsere aktuelle Frucht löschen und eine geschnittene
    // Frucht generieren
    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rbOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionForce);
        }

        FindObjectOfType<GameManager>().IncreaseScore();

        Destroy(inst.gameObject, 7);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Blade b = other.GetComponent<Blade>();
        if (b)
        {
            CreateSlicedFruit();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
