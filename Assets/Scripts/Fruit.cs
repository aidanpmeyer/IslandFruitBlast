using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // public List<GameObject> parts;
    public Transform spawn;
    public GameObject fruitfab1;
    public GameObject fruitfab2;
    public GameObject fruitfab;
    private Vector3 scaleChange;
    private Vector3 scaleLimit, positionChange;
    private Rigidbody rb;
    bool falling;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
        positionChange = new Vector3(0.0f, -0.1f, 0.0f);
        scaleLimit = new Vector3(4, 4, 4);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        falling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!falling)
        {
         //transform.position += Time.deltaTime * positionChange;
         transform.localScale += Time.deltaTime * scaleChange;
                if (transform.localScale.y >= scaleLimit.y)
                {
                    rb.useGravity = true;
                rb.isKinematic = false;
                    falling = true;

                StartCoroutine("Respawn");
                Instantiate(fruitfab, spawn);
            }
        }
       
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate(fruitfab, spawn);
        StopCoroutine("Respawn");
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
        if (other.gameObject.CompareTag("Sword"))
        {
            Debug.Log("split");
            Split();
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);

        }
    }

    void Split()
    {
        GameObject half1 = Instantiate(fruitfab1, transform.position, transform.rotation);
        GameObject half2 = Instantiate(fruitfab2, transform.position, transform.rotation);
        half1.transform.localScale = transform.localScale;
        half2.transform.localScale = transform.localScale;
        Destroy(gameObject);
       
        /*if(parts.Count > 1)
       / {
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

        }*/

    }
}
