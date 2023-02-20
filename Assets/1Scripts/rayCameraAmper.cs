using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCameraAmper : MonoBehaviour
{
    [SerializeField] private GameObject CameraMain;
     private void Start()
    {
        CameraMain = GameObject.Find("Camera");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastFromCursor();
            if (hit.transform != null)
            {
                if (hit.transform.tag == "amperMetr")
                {
                    CameraMain.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
    private RaycastHit CastFromCursor()
    {
        UnityEngine.Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }
}
