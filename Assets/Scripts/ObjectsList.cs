using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="TextAboutMenu")]
public class ObjectsList : ScriptableObject {
    public List<Obj> listObj = new List<Obj>();
}

[Serializable]
public class Obj {
    public int id;
    public string description;
    public string title;
}
