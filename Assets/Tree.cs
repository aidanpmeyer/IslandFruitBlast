using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
 
    private float shakeDuration;
    private float decreaseFactor = 1.0f;
    private Vector3 originalPos;

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

    }

    public void getShook() {
        shakeDuration = 3f;
        // how to make this apply only to fruit on a specific tree?
        GameObject.Find("peach").GetComponent<Fruit>().Drop();
    }
}
