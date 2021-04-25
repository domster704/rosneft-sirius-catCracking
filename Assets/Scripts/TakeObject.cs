using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TakeObject : MonoBehaviour
{

    public Camera _cam;

    static GameObject current_gameObj;

    public GameObject test;

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1")) {
            rayC();
        }

        if (Input.GetButtonDown("Fire2")) {
            putObj();
        }
    }

    private void putObj() {
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit)) {
            // Instantiate(test, hit.point, hit.transform.rotation);
            if (current_gameObj != null) {
                // Instantiate(current_gameObj, hit.point, hit.transform.rotation);

                current_gameObj.SetActive(true);
                current_gameObj.transform.position = hit.point;
                current_gameObj.transform.rotation = hit.transform.rotation;


                current_gameObj = null;
            }
        }
    }

    void rayC() {
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit)) {
            if (hit.collider.name.Contains("Flask")) {
                current_gameObj = hit.collider.gameObject;
                // hit.collider.transform.SetParent(_cam.transform);
                current_gameObj.SetActive(false);
            }
        }
    }
}
