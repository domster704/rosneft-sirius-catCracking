using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTip : MonoBehaviour
{
    private Color color;

    private void Start() {
        color = GetComponent<Renderer>().material.color;
    }

    private void OnMouseEnter() {
        // GetComponent<Renderer>().material.color = Color.black;
    }
    private void OnMouseExit() {
        GetComponent<Renderer>().material.color = color;
    }
}
