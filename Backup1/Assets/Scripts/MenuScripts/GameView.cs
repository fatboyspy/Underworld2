using UnityEngine;
using System.Collections;

public class GameView : MonoBehaviour {
	Gamer targetGamer;
	public GUISkin customSkin;
	public Rect personageRect;
	public Rect statsRect;
	public Rect inventoryRect;
	public Rect optionsRect;
	
	public bool showPersonageWindow;
	public bool showStatsWindow;
	public bool showInventoryWindow;
	
	public int VERTICAL_BOUND;
	public int HORISONTAL_BOUND;
	
	public int PERSONAGE_WINDOW_WIDTH=200;
	public int PERSONAGE_WINDOW_HEIGHT=100;
	
	public int STATS_WINDOW_WIDTH=200;
	public int STATS_WINDOW_HEIGHT=300;
	
	public int INVENTORY_WINDOW_WIDTH=300;
	public int INVENTORY_WINDOW_HEIGHT=350;
	
	public int OPTIONS_WINDOW_WIDTH=200;
	public int OPTIONS_WINDOW_HEIGHT=60;
	
	public int OFFSET=20;
	
	public int CLOSE_BUTTON_SIZE=10;
	public int CLOSE_BUTTON_OFFSET=5;
	
	#region ===свойства===
	public Gamer TargetGamer {
		get {
			return this.targetGamer;
		}
		set {
			targetGamer = value;
		}
	}
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		showPersonageWindow=true;
		showStatsWindow=true;
		showInventoryWindow=true;
		
		VERTICAL_BOUND=Screen.height;
		HORISONTAL_BOUND=Screen.width;
		personageRect = new Rect(OFFSET, OFFSET, PERSONAGE_WINDOW_WIDTH, PERSONAGE_WINDOW_HEIGHT);
		statsRect=new Rect(OFFSET,VERTICAL_BOUND-STATS_WINDOW_HEIGHT-OFFSET,STATS_WINDOW_WIDTH,STATS_WINDOW_HEIGHT);
		inventoryRect=new Rect(HORISONTAL_BOUND-INVENTORY_WINDOW_WIDTH-OFFSET,OFFSET,INVENTORY_WINDOW_WIDTH,INVENTORY_WINDOW_HEIGHT);
		optionsRect=new Rect(HORISONTAL_BOUND-OPTIONS_WINDOW_WIDTH-OFFSET,VERTICAL_BOUND-OPTIONS_WINDOW_HEIGHT-OFFSET,OPTIONS_WINDOW_WIDTH,OPTIONS_WINDOW_HEIGHT);
	}
	
	// Update is called once per frame
	void Update () {	
		
		
	}
	
    void OnGUI() {
		//GUI.skin=customSkin;
        if(showPersonageWindow)personageRect = GUI.Window(0, personageRect, PersonageWindow, "Personage");
		if(showStatsWindow)statsRect=GUI.Window(1,statsRect,StatsWindow,"Basic Characteristics");
		if(showInventoryWindow)inventoryRect=GUI.Window(2,inventoryRect,InventoryWindow,"Inventory");
		optionsRect=GUI.Window(3,optionsRect,OptionsWindow,"Options");
    }
    void PersonageWindow(int windowID) {		
		if(GUI.Button(new Rect(PERSONAGE_WINDOW_WIDTH-CLOSE_BUTTON_SIZE-CLOSE_BUTTON_OFFSET,CLOSE_BUTTON_OFFSET,CLOSE_BUTTON_SIZE,CLOSE_BUTTON_SIZE),GUIContent.none))
			showPersonageWindow=false;
		
		  GUI.DragWindow(new Rect(0, 0, 10000, 10000));
        
    }
	
	void StatsWindow(int windowID)
	{
		if(GUI.Button(new Rect(STATS_WINDOW_WIDTH-CLOSE_BUTTON_SIZE-CLOSE_BUTTON_OFFSET,CLOSE_BUTTON_OFFSET,CLOSE_BUTTON_SIZE,CLOSE_BUTTON_SIZE),GUIContent.none))
			showStatsWindow=false;
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	void InventoryWindow(int windowID)
	{
		if(GUI.Button(new Rect(INVENTORY_WINDOW_WIDTH-CLOSE_BUTTON_SIZE-CLOSE_BUTTON_OFFSET,CLOSE_BUTTON_OFFSET,CLOSE_BUTTON_SIZE,CLOSE_BUTTON_SIZE),GUIContent.none))
			showInventoryWindow=false;
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	void OptionsWindow(int windowID)
	{
		if(GUI.Button(new Rect(CLOSE_BUTTON_OFFSET,OFFSET,30,30),"P")) showPersonageWindow=!showPersonageWindow;
		if(GUI.Button(new Rect(CLOSE_BUTTON_OFFSET*2+30,OFFSET,30,30),"S")) showStatsWindow=!showStatsWindow;
		if(GUI.Button(new Rect(CLOSE_BUTTON_OFFSET*3+30*2,OFFSET,30,30),"I")) showInventoryWindow=!showInventoryWindow;
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
}
