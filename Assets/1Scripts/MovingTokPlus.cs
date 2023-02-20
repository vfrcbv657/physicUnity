using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTokPlus : MonoBehaviour
{
    public bool isQurtetion;
    public float speed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rotate")
        {
            if (this.gameObject.tag == "plus")
            {
                this.gameObject.transform.eulerAngles += new Vector3(0.0f, -90.0f, 0.0f);
            }
        else
                this.gameObject.transform.eulerAngles += new Vector3(0.0f, 90.0f, 0.0f);


        }
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if (this.gameObject.tag == "plus")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
            transform.Translate(Vector3.back * speed * Time.deltaTime); ;
        
    }
}
