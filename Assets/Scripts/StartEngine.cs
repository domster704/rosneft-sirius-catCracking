using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEngine : MonoBehaviour
{
    public static bool isStart = false;
    float speed = 1.0f;
    float amount = 1.0f;

    private void Update() {
        if (isStart) {
            startEng();
        }
    }

    public void startEng() {
        float x = gameObject.transform.position.x * Mathf.Sin(Time.time * speed) * amount;
        float y = gameObject.transform.position.y * Mathf.Sin(Time.time * speed) * amount;
        float z = gameObject.transform.position.z * Mathf.Sin(Time.time * speed) * amount;

        Debug.Log(x + " " + y + " " + z);

        gameObject.transform.position = new Vector3(x, y, z);
    }

    public static void stopEng() {
        isStart = false;
    }
}
