using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralTextObject : MonoBehaviour
{
    public static GeneralTextObject Instance { get; private set; }
    public Text GuiTEXT;

    public GeneralTextObject()
    {
        Instance = this;
    }

    public void Awake()
    {
        GuiTEXT = GetComponent<Text>();
    }

    public void changeText(string text)
    {
        GuiTEXT.text = text;
    }
 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
