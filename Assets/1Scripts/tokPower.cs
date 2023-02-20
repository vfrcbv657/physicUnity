using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tokPower : MonoBehaviour
{
    public float powerAmper;
    public Material lightOn;
    public Material lightOff;
    public Scrollbar AmperScrollbar;
    //private LightControler lightControler;
    

    private void Start()
    {
        AmperScrollbar = GameObject.Find("Scrollbar").GetComponent<Scrollbar>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            
            if (this.gameObject.tag == "plus")
            {
                if (powerAmper >= 20)
                    other.gameObject.transform.GetComponent<LightControler>().OnOffFirePlus(this.gameObject.tag, powerAmper);
                else
                    other.gameObject.transform.GetComponent<LightControler>().OnOffFirePlus(this.gameObject.tag, powerAmper);
            }
            if (this.gameObject.tag == "minus")
            {
                if (powerAmper >= 20)
                    other.gameObject.transform.GetComponent<LightControler>().OnOffFireMinus(this.gameObject.tag, powerAmper);
            }
        }
        if(other.gameObject.tag == "key")
        {
            if (!other.gameObject.transform.GetComponent<KeyControl>().keyIsOn)
            {
                Destroy(this.gameObject);
            }
        }
            
    }
    private void Update()
    {
        powerAmper = AmperScrollbar.value * 10 * 4;
    }
}
