using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruits : MonoBehaviour
{
    public GameObject slicedFruit;
    public GameObject fruitsJuise;
    private float rotationForce = 200;
    private Rigidbody  rb;

    private GameManager gm;
    public int scorePoints;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }


    private void InstantiateSlisedFruit()
    {
        GameObject instantiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject instantiatedJuice = Instantiate(fruitsJuise, new Vector3(transform.position.x, transform.position.y, 0), fruitsJuise.transform.rotation);

        Rigidbody[] slicedRb = instantiatedFruit.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody srb in slicedRb)
        {
            srb.AddExplosionForce(130f, transform.position, 10);
            srb.velocity = rb.velocity * 1.2f;
        }

        Destroy(instantiatedFruit, 5);
        Destroy(instantiatedJuice, 5);
    }

    private void OnMouseDown()
    {
        InstantiateSlisedFruit();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade")
        {
            gm.UpdateTheScore(scorePoints);
            Destroy(gameObject);
            InstantiateSlisedFruit();
        }

        if(other.tag == "BottomTrigger")
        {
            gm.UpdateLives();
        }
    }
}
