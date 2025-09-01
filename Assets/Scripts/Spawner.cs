using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public float left;
    public float right;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            InstantiateRandomObject();
            yield return new WaitForSeconds(RandomRepeatrate());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateRandomObject()
    {
        int objectIndex = Random.Range(0, 6);

        GameObject obj = Instantiate(objects[objectIndex], transform.position, objects[objectIndex].transform.rotation);

        obj.GetComponent<Rigidbody>().AddForce(RandomVector() * RandomForce(), ForceMode.Impulse);

        obj.transform.rotation = Random.rotation;
    }

    private float RandomForce()
    {
        float force = Random.Range(12f, 16f);
        return force;
    }

    private float RandomRepeatrate()
    {
        float repeatrate = Random.Range(0.5f, 3f);
        return repeatrate;
    }

    private Vector2 RandomVector()
    {
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;
        return moveDirection;
    }
}
