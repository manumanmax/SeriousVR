using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RayCast))]
public class CursorColor : MonoBehaviour {
	public int size = 6;
	public GameObject otherGameObject;

	private Texture2D t;
	private Variables vars;
	public bool display = false;
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
		if(!dragOk)
			Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
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
}
