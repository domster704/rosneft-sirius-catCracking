using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TakeObject : MonoBehaviour {

    public Camera _cam;

    static GameObject current_gameObj;
    public GameObject test;

    public TextMeshProUGUI objectInfo;
    public GameObject fire;
    public GameObject steam;
    public GameObject bottle;

    private bool isFill = false;

    private static string mode = "inv";  // grab 

    private int countOfFire = 0;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (mode == "inv") {
                mode = "grab";
            } else {
                mode = "inv";
            }
            if (current_gameObj != null) {
                objectInfo.text = "Object: " + current_gameObj.name + "\nMode: " + mode;
            } else {
                objectInfo.text = "Object: None\nMode: " + mode;
            }
        }

        if (Input.GetButtonDown("Fire1")) {
            rayC();
        }

        if (Input.GetButtonDown("Fire2")) {
            putObj();
        }
    }

    void FixedUpdate()
    {
        
    }

    private void putObj() {
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit)) {
            if (current_gameObj != null) {

                current_gameObj.SetActive(true);
                current_gameObj.transform.position = hit.point;
                // current_gameObj.transform.rotation = hit.transform.rotation;
                current_gameObj.transform.rotation = Quaternion.identity;

                if (mode == "grab") {
                    current_gameObj.transform.parent = null;
                    if (current_gameObj.GetComponent<Rigidbody>() != null) {
                        current_gameObj.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }

                objectInfo.text = "Object: None\n Mode: " + mode;
                current_gameObj = null;
            }
        }
    }

    void rayC() {
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit)) {
            if (hit.collider.GetComponent<Grabbable>() != null && objectInfo.text.Contains("None")) {
                current_gameObj = hit.collider.gameObject;
                objectInfo.text = "Object: " + hit.collider.name + "\n Mode: " + mode;

                countOfFire = 0;
                if (mode == "grab") {
                    hit.collider.transform.SetParent(_cam.transform);
                    if (current_gameObj.GetComponent<Rigidbody>() != null) {
                        current_gameObj.GetComponent<Rigidbody>().isKinematic = true;
                    }
                } else if (mode == "inv") {
                    current_gameObj.SetActive(false);
                }
            } else if (hit.collider.name == "petrol" && objectInfo.text.Contains("torch") && countOfFire == 0) {
                Debug.Log(hit.transform.lossyScale);
                fire.transform.localScale = new Vector3(4, 3, 4);

                hit.collider.gameObject.GetComponent<AudioSource>().Play();

                Instantiate(fire, hit.point + new Vector3(0, 0.05f, 0), hit.transform.rotation);
                countOfFire += 1;
            } else if (hit.collider.name == "Engine" && objectInfo.text.Contains("Canister") && isFill) {
                Instantiate(steam, hit.transform.position + new Vector3(0, 0, 0.1f), Quaternion.Euler(0, 90, 0));
                hit.collider.gameObject.GetComponent<AudioSource>().Play();

                StartEngine.isStart = true;
                isFill = false;
            } else if (hit.collider.name == "MMP" && objectInfo.text.Contains("ForMMP")) {
                Instantiate(bottle, hit.collider.gameObject.transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(90, 0, 0));
            } else if (hit.collider.name.Contains("GasStation") && objectInfo.text.Contains("Canister") && isFill == false) {
                isFill = true;
                Debug.Log(isFill);
            }
        }
    }
}
