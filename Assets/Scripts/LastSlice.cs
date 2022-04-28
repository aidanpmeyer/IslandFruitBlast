using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSlice : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);

        }
    }
}
