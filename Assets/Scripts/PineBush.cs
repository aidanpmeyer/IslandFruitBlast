using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineBush : MonoBehaviour
{
    public GameObject fruitfab;
    public Pineapple one;
    public Transform t1;
    private double respawntime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (one == null) one = Respawn(t1);

    }

    Pineapple Respawn(Transform t)
    {
        GameObject newfruit = Instantiate(fruitfab, t.position, t.rotation);
        
        Pineapple pine = newfruit.GetComponent<Pineapple>();
        return pine;

    }
}
