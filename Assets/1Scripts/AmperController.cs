using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmperController : MonoBehaviour
{
    public GameObject Arrow0;
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;
    public GameObject Arrow5;
    public KeyControl Key;
    public Instalation Instalation;

    private void Start()
    {
        Instalation = GameObject.Find("Camera").GetComponent<Instalation>();
        Key = GameObject.Find("key(Clone)").GetComponent<KeyControl>();
    }
    private void Update()
    {
        if(Key == null)
        {
            Key = GameObject.Find("key(Clone)").GetComponent<KeyControl>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Key.keyIsOn & Instalation.isInstation)
        {
            if (other.gameObject.GetComponent<tokPower>().powerAmper <= 0)
            {
                {
                    Arrow0.SetActive(true);
                    Arrow1.SetActive(false);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(false);
                    Arrow4.SetActive(false);
                }
            }
            if (other.gameObject.GetComponent<tokPower>().powerAmper <= 10)
            {
                {
                    Arrow0.SetActive(false);
                    Arrow1.SetActive(true);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(false);
                    Arrow4.SetActive(false);
                }
            }
            if (other.gameObject.GetComponent<tokPower>().powerAmper <= 20 && other.gameObject.GetComponent<tokPower>().powerAmper >= 10)
            {
                Arrow0.SetActive(false);
                Arrow1.SetActive(false);
                Arrow2.SetActive(true);
                Arrow3.SetActive(false);
                Arrow4.SetActive(false);
            }

            if (other.gameObject.GetComponent<tokPower>().powerAmper <= 30 && other.gameObject.GetComponent<tokPower>().powerAmper >= 20)
            {
                {
                    Arrow0.SetActive(false);
                    Arrow1.SetActive(false);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(true);
                    Arrow4.SetActive(false);
                }
            }
            if (other.gameObject.GetComponent<tokPower>().powerAmper <= 40 && other.gameObject.GetComponent<tokPower>().powerAmper >= 30)
            {
                {
                    Arrow0.SetActive(false);
                    Arrow1.SetActive(false);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(false);
                    Arrow4.SetActive(true);
                }
            }
        }
        else
        {
            Arrow0.SetActive(false);
            Arrow1.SetActive(true);
            Arrow2.SetActive(false);
            Arrow3.SetActive(false);
            Arrow4.SetActive(false);
        }


    }
}
