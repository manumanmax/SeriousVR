using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RayCast))]
public class CursorColor : MonoBehaviour {
	public static int size = 6;
	public GameObject otherGameObject;

	private static Texture2D t;
	public static bool display = false;
    public bool dragOk = false;


	private void Awake () {
		//vars = GameObject.Find ("variables");
		//print (vars);
		t = new Texture2D(size, size, TextureFormat.RGB24, true);
		t.name = "Procedural Texture";
		FillTexture(Color.green);
        
	}

	public void OnMouseEnter () {
        print("entred");
        display = true;
		Cursor.SetCursor(t, Vector2.zero, CursorMode.ForceSoftware);
	}

	public void OnMouseExit() {
        if (!dragOk)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            display = false;
        }
	}

    void OnMouseDown() 
	{
        print("clecked");   
		display = true;
        dragOk = true;

	}
	
	void OnMouseUp () 
	{
        if(display)
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
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
            GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, size, size), t);
        }
        else
        {
            FillTexture(Color.green);
            GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, size, size), t);
        }
    }
}
