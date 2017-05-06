using UnityEngine;
using System.Collections;

public class GameView : MonoBehaviour
{
    public Gamer targetGamer;
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

    public int PERSONAGE_WINDOW_WIDTH = 220;
    public int PERSONAGE_WINDOW_HEIGHT = 125;

    public int STATS_WINDOW_WIDTH = 200;
    public int STATS_WINDOW_HEIGHT = 420;

    public int INVENTORY_WINDOW_WIDTH = 420;
    public int INVENTORY_WINDOW_HEIGHT = 400;
    public Vector2 scrollPosition = Vector2.zero;//начальная позиция скроллинга
    public int INVENTORY_ICON_SIZE=40;
    public string toolTip = "";
    Rect toolTipWindow;//окно тултипа


    public int OPTIONS_WINDOW_WIDTH = 150;
    public int OPTIONS_WINDOW_HEIGHT = 60;

    public int OFFSET = 20;

    public int CLOSE_BUTTON_SIZE = 10;
    public int CLOSE_BUTTON_OFFSET = 5;

    

    // Use this for initialization
    void Start()
    {
        showPersonageWindow = true;
        showStatsWindow = true;
        showInventoryWindow = true;

        VERTICAL_BOUND = Screen.height;
        HORISONTAL_BOUND = Screen.width;
        personageRect = new Rect(OFFSET, OFFSET, PERSONAGE_WINDOW_WIDTH, PERSONAGE_WINDOW_HEIGHT);
        statsRect = new Rect(OFFSET, VERTICAL_BOUND - STATS_WINDOW_HEIGHT - OFFSET, STATS_WINDOW_WIDTH, STATS_WINDOW_HEIGHT);
        inventoryRect = new Rect(HORISONTAL_BOUND - INVENTORY_WINDOW_WIDTH - OFFSET, OFFSET, INVENTORY_WINDOW_WIDTH, INVENTORY_WINDOW_HEIGHT);
        optionsRect = new Rect(HORISONTAL_BOUND - OPTIONS_WINDOW_WIDTH - OFFSET, VERTICAL_BOUND - OPTIONS_WINDOW_HEIGHT - OFFSET, OPTIONS_WINDOW_WIDTH, OPTIONS_WINDOW_HEIGHT);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnGUI()
    {
        if (showPersonageWindow) personageRect = GUI.Window(0, personageRect, PersonageWindow, "Personage");
        if (showStatsWindow) statsRect = GUI.Window(1, statsRect, StatsWindow, "Basic Characteristics");
        if (showInventoryWindow) inventoryRect = GUI.Window(2, inventoryRect, InventoryWindow, "Inventory");
        optionsRect = GUI.Window(3, optionsRect, OptionsWindow, "Options");
        ShowToolTip();
    }
    void PersonageWindow(int windowID)
    {
        if (GUI.Button(new Rect(PERSONAGE_WINDOW_WIDTH - CLOSE_BUTTON_SIZE - CLOSE_BUTTON_OFFSET, CLOSE_BUTTON_OFFSET, CLOSE_BUTTON_SIZE, CLOSE_BUTTON_SIZE), GUIContent.none))
            showPersonageWindow = false;

        #region ===Вывод основных показателей персонажа===
        GUI.Label(new Rect(5, OFFSET, 190, 20),targetGamer.Name,customSkin.GetStyle("Title"));
        GUI.Box(new Rect(5, OFFSET*2, 190 * targetGamer.CurrentHealthPoints / targetGamer.HealthPoints, 20), "", customSkin.GetStyle("HealthBar"));
        GUI.Box(new Rect(5, OFFSET*2, 190, 20), targetGamer.CurrentHealthPoints.ToString() + "/" + targetGamer.HealthPoints.ToString(), customSkin.GetStyle("BarBorder"));
        GUI.Label(new Rect(195, OFFSET*2, 30, 20), "HP",customSkin.GetStyle("Title"));


        GUI.Box(new Rect(5, OFFSET*3, 190 * targetGamer.CurrentManaPoints / targetGamer.ManaPoints, 20), "", customSkin.GetStyle("ManaBar"));
        GUI.Box(new Rect(5, OFFSET*3, 190, 20), targetGamer.CurrentManaPoints.ToString() + "/" + targetGamer.ManaPoints.ToString(), customSkin.GetStyle("BarBorder"));
        GUI.Label(new Rect(195, OFFSET * 3, 30, 20), "MP", customSkin.GetStyle("Title"));

        GUI.Box(new Rect(5, OFFSET*4, 190*targetGamer.Expirience/targetGamer.ExpirienceToLevelUp, 20), "", customSkin.GetStyle("ExpBar"));
        GUI.Box(new Rect(5, OFFSET*4, 190, 20),targetGamer.Expirience.ToString() + "/" + targetGamer.ExpirienceToLevelUp.ToString(), customSkin.GetStyle("BarBorder"));
        GUI.Label(new Rect(195, OFFSET * 4, 30, 20), "XP", customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET*5, 190, 20), "Level - " + targetGamer.Level, customSkin.GetStyle("Title"));
        #endregion
        
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));

    }

    void StatsWindow(int windowID)
    {
        if (GUI.Button(new Rect(STATS_WINDOW_WIDTH - CLOSE_BUTTON_SIZE - CLOSE_BUTTON_OFFSET, CLOSE_BUTTON_OFFSET, CLOSE_BUTTON_SIZE, CLOSE_BUTTON_SIZE), GUIContent.none))
            showStatsWindow = false;
        GUI.Label(new Rect(5, OFFSET, 120, 20), "Strength", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET, 50, 20), "- "+targetGamer.Strength.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 2, 130, 20), "Constitution", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 2, 50, 20), "- "+targetGamer.Constitution.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 3, 130, 20), "Dextirity", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 3, 50, 20), "- " + targetGamer.Dextirity.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 4, 130, 20), "Intelligence", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 4, 50, 20), "- " + targetGamer.Intelligence.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 5, 130, 20), "Witness", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 5, 50, 20), "- " + targetGamer.Wisdom.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 6, 130, 20), "Mental Strength", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 6, 50, 20), "- " + targetGamer.MentalStrength.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 7, 130, 20), "Charisma", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 7, 50, 20), "- " + targetGamer.Charisma.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 8, 130, 20), "Phisical Attack", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 8, 50, 20), "- " + targetGamer.PhisicalAttack.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 9, 130, 20), "Phisical Defence", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 9, 50, 20), "- " + targetGamer.PhisicalDefence.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 10, 130, 20), "Magical Attack", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 10, 50, 20), "- " + targetGamer.MagicalAttack.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 11, 130, 20), "Magical Defence", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 11, 50, 20), "- " + targetGamer.MagicalDefence.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 12, 130, 20), "Accuracy", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 12, 50, 20), "- " + targetGamer.Accuracy.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 13, 130, 20), "Attack Speed", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 13, 50, 20), "- " + targetGamer.PhisicalAttackSpeed.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 14, 130, 20), "Casting Speed", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 14, 50, 20), "- " + targetGamer.CastingSpeed.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 15, 130, 20), "Critacal Chance", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 15, 50, 20), "- " + targetGamer.CriticalChance.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 16, 130, 20), "Critical Power", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 16, 50, 20), "- " + targetGamer.CriticalAttackPower.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 17, 130, 20), "Evasion", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 17, 50, 20), "- " + targetGamer.Evasion.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 18, 130, 20), "Run Speed", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 18, 50, 20), "- " + targetGamer.RunSpeed.ToString(), customSkin.GetStyle("Title"));

        GUI.Label(new Rect(5, OFFSET * 19, 130, 20), "Walk Speed", customSkin.GetStyle("Title"));
        GUI.Label(new Rect(125, OFFSET * 19, 50, 20), "- " + targetGamer.WalkSpeed.ToString(), customSkin.GetStyle("Title"));

        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    void InventoryWindow(int windowID)//функция показа окна инвентаря
    {
        if (GUI.Button(new Rect(INVENTORY_WINDOW_WIDTH - 15, 5, 10, 10), ""))
            showInventoryWindow = false;
        scrollPosition = GUI.BeginScrollView(new Rect(190, 20, 220, 320), scrollPosition, new Rect(0, 0, 100,((targetGamer.Inventory.Capacity/5)+1)*INVENTORY_ICON_SIZE));
        IDictionaryEnumerator indexator = targetGamer.Inventory.Items.GetEnumerator();
        indexator.MoveNext();
        for (int i = 0; i < targetGamer.Inventory.Capacity/5; i++)
        {
            for (int j = 0; j < 5;j++ )
            {
                if (i * 5 + j < targetGamer.Inventory.Items.Count)
                {
                    GUI.Button(new Rect(j * INVENTORY_ICON_SIZE, 15 + i * INVENTORY_ICON_SIZE, INVENTORY_ICON_SIZE, INVENTORY_ICON_SIZE), new GUIContent(((Item)(indexator.Key)).ItemIcon, ((Item)indexator.Key).Name + "\r\n" + "Count: " + indexator.Value.ToString()));
                    indexator.MoveNext();
                }
                else
                {
                    GUI.Box(new Rect(j * INVENTORY_ICON_SIZE, 15 + i * INVENTORY_ICON_SIZE, INVENTORY_ICON_SIZE, INVENTORY_ICON_SIZE), "");
                }
            }
        }
        GUI.EndScrollView();

        GUI.Label(new Rect(190, INVENTORY_WINDOW_HEIGHT - 25, 60, 20),"Slots: "+ targetGamer.Inventory.Items.Count + "/" + targetGamer.Inventory.Capacity, customSkin.GetStyle("Title"));
        GUI.Label(new Rect(280, INVENTORY_WINDOW_HEIGHT - 25, 50, 20), "Load: " + targetGamer.CurrentLoad + "/" + targetGamer.MaxLoad, customSkin.GetStyle("Title"));


        SetToolTip();
        
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));


        //#region ===слот шлема===
        //if (!gamer.PersonageSlots[3].Empty)
        //{
        //    if (GUI.Button(new Rect(100, 15, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[3].EquipItem.ItemIcon, gamer.PersonageSlots[3].EquipItem.ToolTip(gamer.PersonageSlots[3].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[3].EquipItem, 3);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(100, 15, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот правой сережки===
        //if (!gamer.PersonageSlots[8].Empty)
        //{
        //    if (GUI.Button(new Rect(50, 15 + 50, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[8].EquipItem.ItemIcon, gamer.PersonageSlots[8].EquipItem.ToolTip(gamer.PersonageSlots[8].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[8].EquipItem, 8);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(50, 15 + 50, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот ожерелья===
        //if (!gamer.PersonageSlots[7].Empty)
        //{
        //    if (GUI.Button(new Rect(100, 15 + 50, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[7].EquipItem.ItemIcon, gamer.PersonageSlots[7].EquipItem.ToolTip(gamer.PersonageSlots[7].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[7].EquipItem, 7);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(100, 15 + 50, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот левой сережки===
        //if (!gamer.PersonageSlots[4].Empty)
        //{
        //    if (GUI.Button(new Rect(150, 15 + 50, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[4].EquipItem.ItemIcon, gamer.PersonageSlots[4].EquipItem.ToolTip(gamer.PersonageSlots[4].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[4].EquipItem, 4);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(150, 15 + 50, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот оружия===
        //if (!gamer.PersonageSlots[11].Empty)
        //{
        //    if (GUI.Button(new Rect(50, 15 + 100, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[11].EquipItem.ItemIcon, gamer.PersonageSlots[11].EquipItem.ToolTip(gamer.PersonageSlots[11].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[11].EquipItem, 11);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(50, 15 + 100, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот брони===
        //if (!gamer.PersonageSlots[1].Empty)
        //{
        //    if (GUI.Button(new Rect(100, 15 + 100, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[1].EquipItem.ItemIcon, gamer.PersonageSlots[1].EquipItem.ToolTip(gamer.PersonageSlots[1].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[1].EquipItem, 1);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(100, 15 + 100, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот щита===
        //if (!gamer.PersonageSlots[10].Empty)
        //{
        //    if (GUI.Button(new Rect(150, 15 + 100, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[10].EquipItem.ItemIcon, gamer.PersonageSlots[10].EquipItem.ToolTip(gamer.PersonageSlots[10].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[10].EquipItem, 10);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(150, 15 + 100, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот правого кольца===
        //if (!gamer.PersonageSlots[9].Empty)
        //{
        //    if (GUI.Button(new Rect(50, 15 + 150, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[9].EquipItem.ItemIcon, gamer.PersonageSlots[9].EquipItem.ToolTip(gamer.PersonageSlots[9].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[9].EquipItem, 9);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(50, 15 + 150, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот поножей===
        //if (!gamer.PersonageSlots[6].Empty)
        //{
        //    if (GUI.Button(new Rect(100, 15 + 150, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[6].EquipItem.ItemIcon, gamer.PersonageSlots[6].EquipItem.ToolTip(gamer.PersonageSlots[6].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[6].EquipItem, 6);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(100, 15 + 150, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот левого кольца===
        //if (!gamer.PersonageSlots[5].Empty)
        //{
        //    if (GUI.Button(new Rect(150, 15 + 150, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[5].EquipItem.ItemIcon, gamer.PersonageSlots[5].EquipItem.ToolTip(gamer.PersonageSlots[5].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[5].EquipItem, 5);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(150, 15 + 150, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот перчаток===
        //if (!gamer.PersonageSlots[0].Empty)
        //{
        //    if (GUI.Button(new Rect(50, 15 + 200, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[0].EquipItem.ItemIcon, gamer.PersonageSlots[0].EquipItem.ToolTip(gamer.PersonageSlots[0].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[0].EquipItem, 0);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(50, 15 + 200, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region ===слот обуви===
        //if (!gamer.PersonageSlots[2].Empty)
        //{
        //    if (GUI.Button(new Rect(100, 15 + 200, itemIconSize, itemIconSize), new GUIContent(gamer.PersonageSlots[2].EquipItem.ItemIcon, gamer.PersonageSlots[2].EquipItem.ToolTip(gamer.PersonageSlots[2].EquipItem))))
        //    {
        //        gamer.RemoveItemFromSlot(gamer.PersonageSlots[2].EquipItem, 2);
        //    }
        //}
        //else
        //{
        //    GUI.Box(new Rect(100, 15 + 200, itemIconSize, itemIconSize), GUIContent.none);
        //}
        //#endregion

        //#region===вывод информации инвентаря===
        //GUI.Label(new Rect(450, 355, 100, 20), gamer.Stats.CurrentLoad.ToString() + "/" + gamer.Stats.MaxLoad.ToString());
        //GUI.Label(new Rect(450, 375, 100, 20), gamer.Inventory.Count.ToString() + "/" + gamer.InventoryCapacity.ToString());

        //#endregion

        //GUI.DragWindow();
        //SetToolTip();

    }

    void OptionsWindow(int windowID)
    {
        if (GUI.Button(new Rect(CLOSE_BUTTON_OFFSET, OFFSET, 30, 30),(Texture)Resources.Load("Textures/MenuTextures/personage"),customSkin.GetStyle("Icon"))) showPersonageWindow = !showPersonageWindow;
        if (GUI.Button(new Rect(CLOSE_BUTTON_OFFSET * 2 + 30, OFFSET, 30, 30), (Texture)Resources.Load("Textures/MenuTextures/stats"), customSkin.GetStyle("Icon"))) showStatsWindow = !showStatsWindow;
        if (GUI.Button(new Rect(CLOSE_BUTTON_OFFSET * 3 + 30 * 2, OFFSET, 30, 30), (Texture)Resources.Load("Textures/MenuTextures/inventory"), customSkin.GetStyle("Icon"))) showInventoryWindow = !showInventoryWindow;
        if (GUI.Button(new Rect(CLOSE_BUTTON_OFFSET * 4 + 30 * 3, OFFSET, 30, 30), (Texture)Resources.Load("Textures/MenuTextures/exit"), customSkin.GetStyle("Icon"))) Application.Quit();
     //   GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    #region ===функции ===
    void toolWindow(int windowID)
    {
        //for (int i = 1; i < tool.Length; i++)
        //{
        //    if (i == tool.Length - 1)
        //    {
        //        GUI.Box(new Rect(5, i * 15, toolTipWindow.width - 10, 100), tool[i], myStyle);
        //    }
        //    else
        //        GUI.Label(new Rect(5, i * 15, toolTipWindow.width - 10, 20), tool[i]);
        //}

        GUI.Label(new Rect(5, 5,100,40),toolTip,customSkin.GetStyle("Title"));
        GUI.BringWindowToFront(windowID);
        GUI.DragWindow();
    }//функция показа окна тултипа
    //=====установка тултипа
    public void SetToolTip()
    {
        if (Event.current.type == EventType.Repaint && GUI.tooltip != toolTip)
        {
            if (toolTip != "")
                toolTip = "";
            if (GUI.tooltip != "")
                toolTip = GUI.tooltip;
        }
    }

    //=====показ тултипа
    public void ShowToolTip()
    {
        Event e = Event.current;
        if (toolTip != "")
        {
            toolTipWindow = new Rect(e.mousePosition.x + 20, e.mousePosition.y, 150, 60);
            toolTipWindow = GUI.Window(5, toolTipWindow, toolWindow, "");        }
    }
    
    #endregion
}
