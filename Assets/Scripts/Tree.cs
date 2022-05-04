using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
 
    private float shakeDuration;
    private float decreaseFactor = 1.0f;
    private Vector3 originalPos;
    public GameObject fruitfab;
    private Fruit one;
    private Fruit two;
    private Fruit three;
    public Transform t1;
    public Transform t2;
    public Transform t3;


    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        getShook();
    }

    // Update is called once per frame
    void Update()
    {
        var speed = 15.0f; //how fast it shakes
        var amount = 0.045f; //how much it shakes
        if (shakeDuration > 0)
		{	
			float shake = Mathf.Sin(Time.time * speed) * amount;
            gameObject.transform.position = new Vector3(transform.position.x + shake, transform.position.y, transform.position.z);
            shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			transform.position = originalPos;
		}
        if (one == null) one = Respawn( t1);  

        if (two == null) two =  Respawn(t2);
 
        if (three == null) three = Respawn(t3);


    }

    Fruit Respawn(Transform t)
    {
        GameObject newfruit = Instantiate(fruitfab, t.position, t.rotation);
        Fruit fruit = newfruit.GetComponent<Fruit>();
        return fruit;

    }


 

    public void getShook() {
        shakeDuration = 3f;
        StartCoroutine("Drop");
        // how to make this apply only to fruit on a specific tree?
        
        
       
    }

    IEnumerator Drop()
    {
        one.Drop();
        yield return new WaitForSeconds(.5f);
        two.Drop();
        yield return new WaitForSeconds(.5f);
        three.Drop();
    }
}
