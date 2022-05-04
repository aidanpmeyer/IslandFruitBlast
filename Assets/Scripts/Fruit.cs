using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // public List<GameObject> parts
    public GameObject fruitfab1;
    public GameObject fruitfab2;
    private Vector3 scaleChange;
    private Vector3 scaleLimit, positionChange;
    private Rigidbody rb;
    bool falling;
    private ScoreManager scoreManager;
    private AudioSource sliceclip;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
        positionChange = new Vector3(0.0f, -0.1f, 0.0f);
        scaleLimit = new Vector3(3, 3, 3);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        falling = false;
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        sliceclip = GameObject.Find("Canvas").GetComponent<AudioSource>();
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
                    Drop();
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    falling = true;

            }
        }
       
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

    public void Drop() {
        rb.useGravity = true;
        rb.isKinematic = false;
        falling = true;
    }

    void Split()
    {
        scoreManager.score += 1f;
        GameObject half1 = Instantiate(fruitfab1, transform.position, transform.rotation);
        GameObject half2 = Instantiate(fruitfab2, transform.position, transform.rotation);
        half1.transform.localScale = transform.localScale;
        half2.transform.localScale = transform.localScale;
        Destroy(gameObject);
        sliceclip.Play();

     

    }
}
