using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using TMPro;
using Unity.VectorGraphics;

public class ShowAbout : MonoBehaviour
{
    public GameObject info;
    private static string text;
    public string fileName;
    public Vector3 rot = new Vector3(0, 0, .5f);

    public int id;

    private void Start() {
        /*if (info == null) {
            info = GameObject.Find("Canvas/Info");
            Debug.Log(info);
            info.SetActive(false);
        }*/
    }


    private void OnMouseDown() {
        // text = ReadString(fileName);

        var manager = ListManager.onInit();

        // info.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = manager.list.listObj[id].title;
        // info.transform.Find("About").GetComponent<Text>().text = text;
        // info.transform.Find("About").GetComponent<TextMeshProUGUI>().text = manager.list.listObj[id].description;
        info.transform.Find("InfoGraphics").GetComponent<RawImage>().texture = setImageFromRes(id);
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

        transform.Rotate(rot);
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

    private Texture2D setImageFromRes(int id) {
        Texture2D myTexture = Resources.Load<Texture2D>("InfoSVG/" + (id + 0));
        // Debug.Log(myTexture);
        return myTexture;
        /* GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<RawImage>().texture = myTexture; */
    }
}
