using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TakeObject : MonoBehaviour
{

    public Camera _cam;

    static GameObject current_gameObj;
    public GameObject test;

    public TextMeshProUGUI objectInfo;
    public GameObject fire;

    private int countOfFire = 0;

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
                // current_gameObj.transform.rotation = hit.transform.rotation;
                current_gameObj.transform.rotation = Quaternion.identity;

                current_gameObj.transform.parent = null;

                objectInfo.text = "Object: None";
                current_gameObj = null;
            }
        }
    }

    void rayC() {
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit)) {
            if ((hit.collider.name.Contains("Flask") || hit.collider.name.Contains("torch") || hit.collider.name == "canister") && objectInfo.text.Contains("None")) {
                current_gameObj = hit.collider.gameObject;
                objectInfo.text = "Object: " + hit.collider.name;

                countOfFire = 0;
                hit.collider.transform.SetParent(_cam.transform);
                // current_gameObj.SetActive(false);
            } else if (hit.collider.name == "petrol" && objectInfo.text.Contains("torch") && countOfFire == 0) {
                Debug.Log(hit.transform.lossyScale);
                fire.transform.localScale = new Vector3(4, 3, 4);

                Instantiate(fire, hit.point + new Vector3(0, 0.05f, 0), hit.transform.rotation);
                countOfFire += 1;
            } else if (hit.collider.name == "Engine" && objectInfo.text.Contains("canister")) {
                StartEngine.isStart = true;
            }
        }
    }
}
