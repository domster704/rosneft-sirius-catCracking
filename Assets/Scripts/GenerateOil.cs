using UnityEngine;

public class GenerateOil : MonoBehaviour
{

    public GameObject dropOil;

    void Start()
    {
        for (int i = 0; i < 2; i++) {
            Instantiate(dropOil, dropOil.transform.position, dropOil.transform.rotation);
        }
    }

}
