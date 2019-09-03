using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraTest : MonoBehaviour
{

    [SerializeField] private Camera subCamera;
    [SerializeField] private GameObject obj;

    private Rect rect;
    private float rate = 0.01f;

    [SerializeField] private LayerMask mask;

    void Start()
    {
        rect = subCamera.rect;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = subCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 15.0f,mask))
            {
                Instantiate(obj, hit.point, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //rect.x += rate;
            //rect.y += rate;
            //subCamera.rect = rect;
            StartCoroutine(MapActivate(true));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //rect.x -= rate;
            //rect.y -= rate;
            //subCamera.rect = rect;
            StartCoroutine(MapActivate(false));
        }
    }

    private IEnumerator MapActivate(bool actv)
    {
        float end;

        if (actv)
        {

            end = 0;

            while (subCamera.rect.x >= end && subCamera.rect.y >= end)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                rect.x -= rate;
                rect.y -= rate;
                subCamera.rect = rect;
            }
            rect.x = 0;
            rect.y = 0;
            subCamera.rect = rect;
        }
        else
        {

            end = 0.7f;

            while (subCamera.rect.x <= end && subCamera.rect.y <= end)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                rect.x += rate;
                rect.y += rate;
                subCamera.rect = rect;
            }
        }


    }
}
