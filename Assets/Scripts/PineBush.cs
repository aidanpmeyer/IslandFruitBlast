using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineBush : MonoBehaviour
{
    public GameObject fruitfab;
    public Pineapple one;
    public Transform t1;
    private bool respawning;
    private float respawntime;
    // Start is called before the first frame update
    void Start()
    {
        respawntime = 3f;
    }

    // Update is called once per frame
    void Update()
    {


        if (one == null && !respawning)
        {
           
            respawning = true;
            StartCoroutine("Respawn", t1);
        }

    }
    IEnumerator Respawn(Transform t)
    {
        yield return new WaitForSeconds(respawntime);
        GameObject newfruit = Instantiate(fruitfab, t.position, t.rotation);
        Pineapple pine = newfruit.GetComponent<Pineapple>();
        one =  pine;
        respawning = false;

    }
}
