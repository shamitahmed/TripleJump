using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRocket : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.escape)
        {
            transform.position -= Vector3.right * speed * 2 * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.forward * speed * Time.deltaTime;
        }
    }
}
