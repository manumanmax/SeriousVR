using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RayCast))]
public class CursorColor : MonoBehaviour {
	public static int size = 6;
	public GameObject otherGameObject;
    public Vector2 cursorPos;

	private static Texture2D t;
	public static bool display = false;
    public bool dragOk = false;


	private void Awake () {
	    t = new Texture2D(size, size, TextureFormat.RGB24, true);
		t.name = "Procedural Texture";
		FillTexture(Color.green);
        cursorPos = new Vector2(Screen.width / 2, Screen.height / 2 - 10);
	}

	public void OnMouseEnter () {
        display = true;
	}

	public void OnMouseExit() {
        if (!dragOk)
        {
            display = false;
        }
	}

    void OnMouseDown() 
	{
		display = true;
        dragOk = true;

	}
	
	void OnMouseUp () 
	{
		display = false;
        dragOk = false;
        
	}

	private void FillTexture (Color color) {
		for (int y = 0; y < size; y++) {
			for (int x = 0; x < size; x++) {
				t.SetPixel(x, y, color);
			}
		}
		t.Apply();
	}

    void OnGUI()
    {
        
        if (!display)
        {
            FillTexture(Color.red);
            GUI.DrawTexture(new Rect(cursorPos.x, cursorPos.y , size, size), t);
        }
        else
        {
            FillTexture(Color.green);
            GUI.DrawTexture(new Rect(cursorPos.x, cursorPos.y, size, size), t);
        }
    }
}
