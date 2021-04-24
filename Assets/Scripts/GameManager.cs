using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ObjectsList list;

    void Start()
    {
        var manager = ListManager.onInit();
        manager.list = list;
    }

}
