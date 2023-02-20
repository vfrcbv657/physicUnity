using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instalation : MonoBehaviour
{
    public GameObject amperMetr, key;
    public GameObject Cabel1;
    public GameObject Cabel2;
    public GameObject LightCabels;
    public bool isOnPlace1;
    public bool isOnPlace11;
    public bool isOnPlace2;
    public bool isOnPlace22;
    public bool isInstation;
    public GameObject spawn;
    public GameObject tok;
    public GameObject minus;
    public GameObject errorMes;
    public GameObject OtherPrefab = null, OtherButton = null, place1obj, place2obj; //пустышка для создания объетка
    private Camera mainCameraFull;
    private bool CamLookAt; // g
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastFromCursor();
            if (hit.transform != null)
            {
                if(mainCameraFull == this.gameObject.GetComponent<Camera>())
                {
                    if (hit.transform.tag == "place1" /*|| hit.transform.tag == "key" || hit.transform.tag == "amperMetr"*/)
                    {
                        if (OtherPrefab != null)
                        {
                            if (isOnPlace1 == true)
                            {
                                Destroy(place1obj);
                            }
                            isOnPlace1 = true;
                            place1obj = Instantiate(OtherPrefab, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), Quaternion.identity);
                            OtherPrefab = null;
                        }

                    }
                    if (hit.transform.tag == "place2" /*|| hit.transform.tag == "key" || hit.transform.tag == "amperMetr"*/)
                    {
                        if (OtherPrefab != null)
                        {
                            if (isOnPlace2 == true)
                            {
                                Destroy(place2obj);
                            }
                            isOnPlace2 = true;
                            place2obj = Instantiate(OtherPrefab, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), Quaternion.identity);
                            OtherPrefab = null;
                        }
                    }
                }
                
                if (hit.transform.tag == "Start")
                {
                    if (isOnPlace1 && isOnPlace2)
                    {
                        isInstation = !isInstation;
                        spawning();
                    }
                    else {
                        errorMes.SetActive(true);
                        StartCoroutine(error());
                    }
                        
                    
                }
                if(hit.transform.tag == "key")
                {
                    hit.transform.gameObject.GetComponent<KeyControl>().GetOnOff();
                }
                if (hit.transform.tag == "amperMetr")
                {
                    hit.transform.Find("amperCamera").gameObject.SetActive(!hit.transform.Find("amperCamera").gameObject.active);
                    if (hit.transform.Find("amperCamera").gameObject.active)
                    {
                        mainCameraFull = hit.transform.Find("amperCamera").gameObject.GetComponent<Camera>();
                    }
                    else
                    {
                        mainCameraFull = this.gameObject.GetComponent<Camera>();
                    }
                }
            }

        }
    }
    IEnumerator error()
    {
        yield return new WaitForSeconds(2);
        errorMes.SetActive(false);
    }
    private void spawning()
    {
        StartCoroutine(SpawnBox(0.5f));
    }
    public void Choice(string name)
    {
        if(name == "key")
        {
            OtherPrefab = key;
            
        }
        if (name == "amperMetr")
        {
            OtherPrefab = amperMetr;
        }
    }
    IEnumerator SpawnBox(float time)
    {
        if (isInstation)
        {
            yield return new WaitForSeconds(time);
            Instantiate(minus, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), Quaternion.AngleAxis(90, Vector3.up));
            Instantiate(tok, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), Quaternion.AngleAxis(90, Vector3.up));
            spawning();
        }
        
    }
    private RaycastHit CastFromCursor()
    {
        UnityEngine.Ray ray = mainCameraFull.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }
    private void Start()
    {
        mainCameraFull = this.gameObject.GetComponent<Camera>();
    }
}
