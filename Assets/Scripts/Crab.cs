using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crab1;
    public GameObject crab2;
    private ScoreManager scoreManager;
    private float speed;
    private float amount;
    public Transform crabarm;
    private Vector3 dir;


   
    private float decreaseFactor = 1.0f;
    private Vector3 originalPos;
    void Start()
    {

        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        speed = 2.0f; //how fast it shakes
        amount = 0.05f; //how much it shakes
        dir = crabarm.position - transform.position;
    }

    private void Update()
    {
   
            float shake = Mathf.Sin(Time.time * speed) * amount;
            //gameObject.transform.position = new Vector3(transform.position.x + shake, transform.position.y, transform.position.z);
            gameObject.transform.position = transform.position + shake*(dir);

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
        void Split()
        {
            scoreManager.score += 1f;
            GameObject half1 = Instantiate(crab1, transform.position, transform.rotation);
            GameObject half2 = Instantiate(crab2, transform.position, transform.rotation);
            half1.transform.localScale = transform.localScale;
            half2.transform.localScale = transform.localScale;
            Destroy(gameObject);

        }
    }
}
