using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public List<GameObject> parts;
    public GameObject fruitfab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
        if (other.gameObject.CompareTag("Sword"))
        {
            Debug.Log("split");
            Split();
        }
    }

    void Split()
    {
        if(parts.Count > 1)
        {
            Debug.Log("yay");
            GameObject one = Instantiate(fruitfab,transform.position,transform.rotation);
            Fruit fruitone = one.GetComponent<Fruit>();
            GameObject two = Instantiate(fruitfab, transform.position, transform.rotation);
            Fruit fruittwo = two.GetComponent<Fruit>();
            for (int i = 0; i < parts.Count; i++)
            {
                if (i < parts.Count / 2)
                {
                    GameObject part = parts[i];
                    part.transform.parent = one.transform;
                    fruitone.parts[i] = part;
                }
                else
                {
                    GameObject part = parts[i];
                    part.transform.parent = two.transform;
                    fruittwo.parts[i- parts.Count/2] = part;
                }
            }
            DestroyObject(this);

        }

    }
}
