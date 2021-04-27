using UnityEngine;

public class GenerateOil : MonoBehaviour
{

    public GameObject dropOil;
    public GameObject place;

    void Start()
    {
        for (int i = 0; i < 4; i++) {
            Instantiate(dropOil, place.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        }
    }

}
