using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class ShowAbout : MonoBehaviour
{
    public GameObject info;
    private static string text;
    public string fileName;

    private void OnMouseDown() {
        text = ReadString(fileName);
        info.transform.Find("Title").GetComponent<Text>().text = "XD";
        info.transform.Find("About").GetComponent<Text>().text = (string) text;
        info.SetActive(true);
    }

    private void OnMouseExit() {
        info.transform.Find("Title").GetComponent<Text>().text = "";
        info.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            info.SetActive(false);
        }
    }

    private string ReadString(string fileName) {
        TextAsset textFile = Resources.Load<TextAsset>("Data/" + fileName);
        return textFile.ToString();
    }

    /*void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button")) {
            print("You clicked the button!");
        }
    }*/
}
