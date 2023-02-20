using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControler : MonoBehaviour
{
    public bool plus, minus, couratine;
    public Material lightOn;
    public Material lightOff;
    [SerializeField] private GameObject lightning;
    void Update()
    {
        if (plus && minus)
            lightning.GetComponent<MeshRenderer>().material = lightOn;
        else
            lightning.GetComponent<MeshRenderer>().material = lightOff;
    }
    public void OnOffFirePlus(string tagName, float Amper)
    {
        plus = true;
        if (minus == true)
        {
            StartCoroutine(ToFalse());
            couratine = true;
        }
            
    }
    public void stopLight()
    {
        plus = false;
    }
    public void OnOffFireMinus(string tagName, float Amper)
    {
        minus = true;
        if(couratine == true)
            StopAllCoroutines();
            couratine = false;

    }
    IEnumerator ToFalse()
    {
        yield return new WaitForSeconds(0.8f);
        minus = false;
        couratine = false;
    }


}
