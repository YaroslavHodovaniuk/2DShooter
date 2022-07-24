using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOnRadius : MonoBehaviour
{
    public GameObject Template;
    public int Count;
    public float Radius;
    void Start()
    {
        int agleStep = 360 / Count;
        for(int i = 0; i < Count; i++)
        {
            GameObject newObject = Instantiate(Template, Vector3.zero, Quaternion.identity);
            Transform newObjectTransform = newObject.GetComponent<Transform>();
            newObjectTransform.position = new Vector3(Radius * Mathf.Cos(agleStep * i * Mathf.Deg2Rad), Radius * Mathf.Sin(agleStep * i * Mathf.Deg2Rad), 0);

        }
    }
}
