using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using TMPro;

public class ShowAbout : MonoBehaviour
{
    public GameObject info;
    private static string text;
    public string fileName;

    public int id;

    private void OnMouseDown() {
        // text = ReadString(fileName);

        var manager = ListManager.onInit();

        info.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = manager.list.listObj[id].title;
        // info.transform.Find("About").GetComponent<Text>().text = text;
        info.transform.Find("About").GetComponent<TextMeshProUGUI>().text = manager.list.listObj[id].description;
        info.SetActive(true);
    }

    private void OnMouseExit() {
        // info.transform.Find("Title").GetComponent<TextMeshPro>().text = "";
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
