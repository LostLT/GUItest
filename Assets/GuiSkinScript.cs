using UnityEngine;
using System.Collections;

public class GuiSkinScript : MonoBehaviour {

    public GUISkin[] s1;
    public GameObject tdTextObject;
    public GameObject guiTextObject;
    public Font georgiaTTF;
    public Font courTTF;
    private float hSliderValue = 0.0F;
    private float vSliderValue = 0.0F;
    private float hSValue = 0.0F;
    private float vSValue = 0.0F;
    private int cont = 0;

    void Update() 
    {
        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetKeyDown(KeyCode.Space)))
        {
            cont++;

            Debug.Log("Before tdTextObject font name = " + tdTextObject.GetComponent<TextMesh>().font.name);
            Debug.Log("Before guiTextObject font name = " + guiTextObject.guiText.font.name);

            if ((cont % s1.Length) == 1)
            {
                tdTextObject.GetComponent<TextMesh>().font = georgiaTTF;
                guiTextObject.guiText.font = courTTF;
            }
            else
            {
                tdTextObject.GetComponent<TextMesh>().font = courTTF;
                guiTextObject.guiText.font = georgiaTTF;
            }

            Debug.Log("Now tdTextObject font name = " + tdTextObject.GetComponent<TextMesh>().font.name);
            Debug.Log("Now guiTextObject font name = " + guiTextObject.guiText.font.name);
        }
        
    }
    void OnGUI() 
    {
        GUI.skin = s1[cont % s1.Length];
        if (s1.Length == 0) {
            Debug.LogError("Assign at least 1 skin on the array");
            return;
        }
        GUI.Label(new Rect(10, 10, 700, 30), "Hello World! Aš ją parašė lietuvių. И еще вот тут по-русски");
        GUI.Box(new Rect(10, 50, 100, 50), "Aš BOX");
        if (GUI.Button(new Rect(10, 110, 100, 30), "Aš button"))
            Debug.Log("Button has been pressed");
        
        hSliderValue = GUI.HorizontalSlider(new Rect(10, 150, 100, 30), hSliderValue, 0.0F, 10.0F);
        vSliderValue = GUI.VerticalSlider(new Rect(10, 170, 100, 30), vSliderValue, 10.0F, 0.0F);
        hSValue = GUI.HorizontalScrollbar(new Rect(10, 210, 100, 30), hSValue, 1.0F, 0.0F, 10.0F);
        vSValue = GUI.VerticalScrollbar(new Rect(10, 230, 100, 30), vSValue, 1.0F, 10.0F, 0.0F);
    }
}
