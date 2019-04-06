using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingtextcontroller : MonoBehaviour {
    private static floatingtext popuptext;
    private static GameObject canvas;
    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popuptext = Resources.Load<floatingtext>("Prefabs/Holder");
    }

	public static void createfloatingtext(string text, Transform location)
    {
        floatingtext instance = Instantiate(popuptext);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }
}
