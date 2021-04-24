using UnityEngine;
using UnityEngine.SceneManagement;

public class DoTeleport : MonoBehaviour
{
    public string sceneName;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            SceneManager.LoadScene(sceneName);
        }
    }
}
