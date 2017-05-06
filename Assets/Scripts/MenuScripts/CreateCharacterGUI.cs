using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CreateCharacterGUI : MonoBehaviour
{
    public UnityEngine.Object playerObject;
    public GameObject playerCharacter;
    Vector3 instantiationPoint;
    CreatureGender currentGender;
    PlayerOccupation currentOccupation;
    PlayerRace currentRace;
    //шкурка меню
    public GUISkin customSkin;
    //параметры элементов меню
    public float leftOffset;
    public float topOffset;
    public float baseStatsGroupWidth;
    public float baseStatsGroupHeight;
    public float standartLabelWidth;
    public float standartLabelHeight;
    public float offset;
    public float valuesLabelWidth;
    public float valuesLabelHeight;
    public float valuesButtonWidth;
    public float valuesButtonHeight;
    public float barHeight;

    public float createButtonWidth;
    public float createButtonHeight;

    //все комбо-боксы
    public ComboBox cbRaces = new ComboBox();
    public ComboBox cbGenders = new ComboBox();
    public ComboBox cbOccupations = new ComboBox();
    public ComboBox cbFaces = new ComboBox();
    public ComboBox cbHairStyles = new ComboBox();
    public ComboBox cbHairColors = new ComboBox();

    Gamer gamer;//обьект игрока
    //==========================================================================

    int pointsLeft = 10;

    string[] races;
    string[] genders;
    string[] occupations;
    public UnityEngine.Object[] faces;
    public UnityEngine.Object[] hairStyles;
    public UnityEngine.Object[] hairColors;

    public GUIContent[] raceContent;
    public GUIContent[] genderContent;
    public GUIContent[] occupationContent;
    public GUIContent[] faceContent;
    public GUIContent[] hairStyleContent;
    public GUIContent[] hairColorContent;
    public GUIStyle listStyle = new GUIStyle();

    // Use this for initialization
    void Start()
    {
        instantiationPoint = new Vector3(15f, 0.1f, 6f);
        leftOffset = 5;
        topOffset = 5;
        baseStatsGroupWidth = 350;
        baseStatsGroupHeight = 800;
        standartLabelWidth=160;
        standartLabelHeight=27;
        offset=0;
        valuesLabelWidth=85;
        valuesLabelHeight=27;
        valuesButtonWidth=45;
        valuesButtonHeight=27;
        barHeight=20;

        createButtonWidth=120;
        createButtonHeight=30;

        listStyle.normal.textColor = Color.white;
        listStyle.onHover.background =
        listStyle.hover.background = new Texture2D(2, 2);
        listStyle.padding.left =
        listStyle.padding.right =
        listStyle.padding.top =
        listStyle.padding.bottom = 4;

        #region заполняем расы
        races = Enum.GetNames(typeof(PlayerRace));
        raceContent = new GUIContent[races.Length];
        for (int i = 0; i < races.Length; i++)
            raceContent[i] = new GUIContent(races[i]);
        #endregion

        #region заполняем пол
        genders = Enum.GetNames(typeof(CreatureGender));
        genderContent = new GUIContent[genders.Length];
        for (int i = 0; i < genders.Length; i++)
            genderContent[i] = new GUIContent(genders[i]);
        #endregion
        
        #region заполняем профы
        occupations = Enum.GetNames(typeof(PlayerOccupation));
        occupationContent = new GUIContent[occupations.Length];
        for (int i = 0; i < occupations.Length; i++)
            occupationContent[i] = new GUIContent(occupations[i]);
        #endregion

        #region заполняем лица
        /*
        faces = Resources.LoadAll("Faces", typeof(GameObject));
        faceContent = new GUIContent[faces.Length];
        for (int i = 0; i < faces.Length; i++)
            faceContent[i] = new GUIContent(faces[i].name);
         * */
        #endregion

        #region заполняем прически
        hairStyles = Resources.LoadAll("HairStyles");
        hairStyleContent = new GUIContent[hairStyles.Length];
        for (int i = 0; i < hairStyles.Length; i++)
            hairStyleContent[i] = new GUIContent(hairStyles[i].name);
        #endregion

        #region заполняем цвета причесок
        hairColors = Resources.LoadAll("HairColors");
        hairColorContent = new GUIContent[hairColors.Length];
        for (int i = 0; i < hairColors.Length; i++)
            hairColorContent[i] = new GUIContent(hairColors[i].name);
        #endregion

        currentRace = (PlayerRace)0;
        currentGender = (CreatureGender)0;
        currentOccupation = (PlayerOccupation)0;
        gamer = new Gamer("", currentRace, currentGender, currentOccupation, 1, 5, 5, 5, 5, 5, 5, 5);
        InstantiateModel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = customSkin;

        #region Базовые характеристики
        GUI.BeginGroup(new Rect(leftOffset, topOffset, baseStatsGroupWidth, baseStatsGroupHeight));
        GUI.Label(new Rect(offset + (baseStatsGroupWidth - standartLabelWidth) / 2, offset, standartLabelWidth, standartLabelHeight), "Points left - " + pointsLeft.ToString());

        #region Strength
        GUI.Label(new Rect(offset, standartLabelHeight + offset, standartLabelWidth, standartLabelHeight), "Strength");
        GUI.Label(new Rect(offset + standartLabelWidth, standartLabelHeight + offset, valuesLabelWidth, valuesLabelHeight), gamer.Strength.ToString());
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth, standartLabelHeight + offset, valuesButtonWidth, valuesButtonHeight), "-"))
        {
            if (gamer.Strength > 1)
            {
                gamer.Strength--;
                pointsLeft++;
            }
        }
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth + valuesButtonWidth, standartLabelHeight + offset, valuesButtonWidth, valuesButtonHeight), "+"))
        {
            if (pointsLeft > 0)
            {
                gamer.Strength++;
                pointsLeft--;
            }
        }
        #endregion

        #region Constitution
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 2, standartLabelWidth, standartLabelHeight), "Constitution");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 2, valuesLabelWidth, valuesLabelHeight), gamer.Constitution.ToString());
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth, (standartLabelHeight + offset) * 2, valuesButtonWidth, valuesButtonHeight), "-"))
        {
            if (gamer.Constitution > 1)
            {
                gamer.Constitution--;
                pointsLeft++;
            }
        }
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth + valuesButtonWidth, (standartLabelHeight + offset) * 2, valuesButtonWidth, valuesButtonHeight), "+"))
        {
            if (pointsLeft > 0)
            {
                gamer.Constitution++;
                pointsLeft--;
            }
        }
        #endregion

        #region Dextirity
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 3, standartLabelWidth, standartLabelHeight), "Dextirity");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 3, valuesLabelWidth, valuesLabelHeight), gamer.Dextirity.ToString());
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth, (standartLabelHeight + offset) * 3, valuesButtonWidth, valuesButtonHeight), "-"))
        {
            if (gamer.Dextirity > 1)
            {
                gamer.Dextirity--;
                pointsLeft++;
            }
        }
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth + valuesButtonWidth, (standartLabelHeight + offset) * 3, valuesButtonWidth, valuesButtonHeight), "+"))
        {
            if (pointsLeft > 0)
            {
                gamer.Dextirity++;
                pointsLeft--;
            }
        }
        #endregion

        #region Intelligence
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 4, standartLabelWidth, standartLabelHeight), "Intelligence");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 4, valuesLabelWidth, valuesLabelHeight), gamer.Intelligence.ToString());
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth, (standartLabelHeight + offset) * 4, valuesButtonWidth, valuesButtonHeight), "-"))
        {
            if (gamer.Intelligence > 1)
            {
                gamer.Intelligence--;
                pointsLeft++;
            }
        }
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth + valuesButtonWidth, (standartLabelHeight + offset) * 4, valuesButtonWidth, valuesButtonHeight), "+"))
        {
            if (pointsLeft > 0)
            {
                gamer.Intelligence++;
                pointsLeft--;
            }
        }
        #endregion

        #region Wsdom
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 5, standartLabelWidth, standartLabelHeight), "Wisdom");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 5, valuesLabelWidth, valuesLabelHeight), gamer.Wisdom.ToString());
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth, (standartLabelHeight + offset) * 5, valuesButtonWidth, valuesButtonHeight), "-"))
        {
            if (gamer.Wisdom > 1)
            {
                gamer.Wisdom--;
                pointsLeft++;
            }
        }
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth + valuesButtonWidth, (standartLabelHeight + offset) * 5, valuesButtonWidth, valuesButtonHeight), "+"))
        {
            if (pointsLeft > 0)
            {
                gamer.Wisdom++;
                pointsLeft--;
            }
        }
        #endregion

        #region Mental Strength
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 6, standartLabelWidth, standartLabelHeight), "Mental strength");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 6, valuesLabelWidth, valuesLabelHeight), gamer.MentalStrength.ToString());
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth, (standartLabelHeight + offset) * 6, valuesButtonWidth, valuesButtonHeight), "-"))
        {
            if (gamer.MentalStrength > 1)
            {
                gamer.MentalStrength--;
                pointsLeft++;
            }
        }
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth + valuesButtonWidth, (standartLabelHeight + offset) * 6, valuesButtonWidth, valuesButtonHeight), "+"))
        {
            if (pointsLeft > 0)
            {
                gamer.MentalStrength++;
                pointsLeft--;
            }
        }
        #endregion

        #region Charisma
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 7, standartLabelWidth, standartLabelHeight), "Charisma");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 7, valuesLabelWidth, valuesLabelHeight), gamer.Charisma.ToString());
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth, (standartLabelHeight + offset) * 7, valuesButtonWidth, valuesButtonHeight), "-"))
        {
            if (gamer.Charisma > 1)
            {
                gamer.Charisma--;
                pointsLeft++;
            }
        }
        if (GUI.Button(new Rect(offset + standartLabelWidth + valuesLabelWidth + valuesButtonWidth, (standartLabelHeight + offset) * 7, valuesButtonWidth, valuesButtonHeight), "+"))
        {
            if (pointsLeft > 0)
            {
                gamer.Charisma++;
                pointsLeft--;
            }
        }
        #endregion

        #region Health
        GUI.Box(new Rect(offset, (standartLabelHeight + offset) * 8, standartLabelWidth, barHeight), "", GUI.skin.GetStyle("HealthBar"));
        GUI.Box(new Rect(offset, (standartLabelHeight + offset) * 8, standartLabelWidth, barHeight), gamer.HealthPoints.ToString(), GUI.skin.GetStyle("BarBorder"));
        #endregion

        #region Mana
        GUI.Box(new Rect(offset, (standartLabelHeight + offset) * 9, standartLabelWidth, barHeight), "", GUI.skin.GetStyle("ManaBar"));
        GUI.Box(new Rect(offset, (standartLabelHeight + offset) * 9, standartLabelWidth, barHeight), gamer.ManaPoints.ToString(), GUI.skin.GetStyle("BarBorder"));
        #endregion

        #region P.Attack
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 10, standartLabelWidth, standartLabelHeight), "P.Attack");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 10, valuesLabelWidth, valuesLabelHeight), gamer.PhisicalAttack.ToString());
        #endregion

        #region P.Defence
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 11, standartLabelWidth, standartLabelHeight), "P.Defence");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 11, valuesLabelWidth, valuesLabelHeight), gamer.PhisicalDefence.ToString());
        #endregion

        #region M.Attack
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 12, standartLabelWidth, standartLabelHeight), "M.Attack");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 12, valuesLabelWidth, valuesLabelHeight), gamer.MagicalAttack.ToString());
        #endregion

        #region M.Defence
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 13, standartLabelWidth, standartLabelHeight), "M.Defence");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 13, valuesLabelWidth, valuesLabelHeight), gamer.MagicalDefence.ToString());
        #endregion

        #region Accuracy
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 14, standartLabelWidth, standartLabelHeight), "Accuracy");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 14, valuesLabelWidth, valuesLabelHeight), gamer.Accuracy.ToString());
        #endregion

        #region Attack speed
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 15, standartLabelWidth, standartLabelHeight), "Attack speed");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 15, valuesLabelWidth, valuesLabelHeight), gamer.PhisicalAttackSpeed.ToString());
        #endregion

        #region Casting speed
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 16, standartLabelWidth, standartLabelHeight), "Casting speed");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 16, valuesLabelWidth, valuesLabelHeight), gamer.CastingSpeed.ToString());
        #endregion

        #region Critical chance
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 17, standartLabelWidth, standartLabelHeight), "Critical chance");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 17, valuesLabelWidth, valuesLabelHeight), gamer.CriticalChance.ToString());
        #endregion

        #region Critical power
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 18, standartLabelWidth, standartLabelHeight), "Critical power");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 18, valuesLabelWidth, valuesLabelHeight), gamer.CriticalAttackPower.ToString());
        #endregion

        #region Evasion
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 19, standartLabelWidth, standartLabelHeight), "Evasion");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 19, valuesLabelWidth, valuesLabelHeight), gamer.Evasion.ToString());
        #endregion

        #region Run speed
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 20, standartLabelWidth, standartLabelHeight), "Run speed");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 20, valuesLabelWidth, valuesLabelHeight), gamer.RunSpeed.ToString());
        #endregion

        #region Walk speed
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 21, standartLabelWidth, standartLabelHeight), "Walk speed");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 21, valuesLabelWidth, valuesLabelHeight), gamer.WalkSpeed.ToString());
        #endregion

        #region Max load
        GUI.Label(new Rect(offset, (standartLabelHeight + offset) * 22, standartLabelWidth, standartLabelHeight), "Max load");
        GUI.Label(new Rect(offset + standartLabelWidth, (standartLabelHeight + offset) * 22, 120, valuesLabelHeight), gamer.MaxLoad.ToString());
        #endregion

        //пересчет характеристик
        gamer.CalculateStats();
        GUI.EndGroup();
        #endregion

        #region Внешний вид
        GUI.BeginGroup(new Rect(Screen.width - baseStatsGroupWidth - offset, offset, baseStatsGroupWidth, baseStatsGroupHeight));
        GUI.Label(new Rect(offset, offset, standartLabelWidth, standartLabelHeight), "Name");
        gamer.Name = GUI.TextField(new Rect(offset + standartLabelWidth, offset, standartLabelWidth, standartLabelHeight), gamer.Name);
        gamer.Name = gamer.Name.Trim();

        #region Вывод рас
        int raceIndex = cbRaces.GetSelectedItemIndex();
        GUI.Label(new Rect(offset, (offset + standartLabelHeight), standartLabelWidth, standartLabelHeight), "Race");
        raceIndex = cbRaces.List(new Rect(offset + standartLabelWidth, (offset + standartLabelHeight), standartLabelWidth, standartLabelHeight), raceContent[raceIndex].text, raceContent, listStyle);
        currentRace = (PlayerRace)raceIndex;
        if (currentRace != gamer.Race)
        {
            gamer.Race = currentRace;
            Destroy(playerObject);
            InstantiateModel();
        }
        else gamer.Race = (PlayerRace)raceIndex;
        #endregion

        #region Вывод полов
        int genderIndex = cbGenders.GetSelectedItemIndex();
        GUI.Label(new Rect(offset, (offset + standartLabelHeight) * 2, standartLabelWidth, standartLabelHeight), "Gender");
        genderIndex = cbGenders.List(new Rect(offset + standartLabelWidth, (offset + standartLabelHeight) * 2, standartLabelWidth, standartLabelHeight), genderContent[genderIndex].text, genderContent, listStyle);
        currentGender = (CreatureGender)genderIndex;
        if (currentGender != gamer.Gender)
        {
            gamer.Gender = currentGender;
            Destroy(playerObject);
            InstantiateModel();
        }
        else gamer.Gender = (CreatureGender)genderIndex;
        #endregion

        #region Вывод проффессий
        int occupationIndex = cbOccupations.GetSelectedItemIndex();
        if (gamer.Race == PlayerRace.Dwarf)
        {
            occupations = new string[1] { PlayerOccupation.Fighter.ToString() };
            occupationContent = new GUIContent[1];
            occupationContent[0] = new GUIContent(occupations[0]);
            occupationIndex = 0;
        }
        else
        {
            #region заполняем профы
            occupations = Enum.GetNames(typeof(PlayerOccupation));
            occupationContent = new GUIContent[occupations.Length];
            for (int i = 0; i < occupations.Length; i++)
                occupationContent[i] = new GUIContent(occupations[i]);
            #endregion
        }
        GUI.Label(new Rect(offset, (offset + standartLabelHeight) * 3, standartLabelWidth, standartLabelHeight), "Occupation");
        occupationIndex = cbOccupations.List(new Rect(offset + standartLabelWidth, (offset + standartLabelHeight) * 3, standartLabelWidth, standartLabelHeight), occupationContent[occupationIndex].text, occupationContent, listStyle);
        currentOccupation = (PlayerOccupation)occupationIndex;
        if (currentOccupation != gamer.Occupation)
        {
            gamer.Occupation = currentOccupation;
            Destroy(playerObject);
            InstantiateModel();
        }
        else gamer.Occupation = (PlayerOccupation)occupationIndex;
        #endregion

        //#region Вывод фейсов
        //int faceIndex = cbFaces.GetSelectedItemIndex();
        //GUI.Label(new Rect(offset, (offset + standartLabelHeight) * 4, standartLabelWidth, standartLabelHeight), "Face");
        ////faceIndex = cbFaces.List(new Rect(offset + standartLabelWidth, (offset + standartLabelHeight) * 4, standartLabelWidth, standartLabelHeight), faceContent[faceIndex].text, faceContent, listStyle); 
        //#endregion

        //#region Вывод стилей причесок
        //int hairStyleIndex = cbHairStyles.GetSelectedItemIndex();
        //GUI.Label(new Rect(offset, (offset + standartLabelHeight) * 5, standartLabelWidth, standartLabelHeight), "Hair style");
        ////hairStyleIndex = cbHairStyles.List(new Rect(offset + standartLabelWidth, (offset + standartLabelHeight) * 5, standartLabelWidth, standartLabelHeight), hairStyleContent[hairStyleIndex].text, hairStyleContent, listStyle); 
        //#endregion

        //#region Вывод цветов причесок
        //int hairColorIndex = cbHairColors.GetSelectedItemIndex();
        //GUI.Label(new Rect(offset, (offset + standartLabelHeight) * 6, standartLabelWidth, standartLabelHeight), "Hair color");
        ////hairColorIndex = cbHairColors.List(new Rect(offset + standartLabelWidth, (offset + standartLabelHeight) * 5, standartLabelWidth, standartLabelHeight), hairColorContent[hairColorIndex].text, hairColorContent, listStyle);
        //#endregion

        GUI.EndGroup();
        #endregion

        #region Кнопка "Создать"
        if (pointsLeft == 0 && gamer.Name != ""&& gamer.Race==PlayerRace.Human&&gamer.Gender==CreatureGender.Female&&gamer.Occupation==PlayerOccupation.Fighter)
        {
            if (GUI.Button(new Rect((Screen.width - createButtonWidth) / 2, Screen.height - createButtonHeight - offset, createButtonWidth, createButtonHeight), "Create"))
            {
                SaveParameters();
                Application.LoadLevel(2);
            }
        }
        else
            GUI.Button(new Rect((Screen.width - createButtonWidth) / 2, Screen.height - createButtonHeight - offset, createButtonWidth, createButtonHeight), "Creating...");
        #endregion
    }
    /// <summary>
    /// Смена модели персонажа
    /// </summary>
    private void InstantiateModel()
    {
        playerCharacter = (GameObject)Resources.Load("Models/PlayerModels/" + gamer.Race.ToString() + "/" + gamer.Gender.ToString() + "/" + gamer.Occupation.ToString() + "/Prefab/ModelPrefab");
        playerCharacter.AddComponent(typeof(CharacterWaiting));
        playerObject= Instantiate(playerCharacter, instantiationPoint, Quaternion.AngleAxis(180, Vector3.up));
    }

    /// <summary>
    /// Сохранение параметров
    /// </summary>
    private void SaveParameters()
    {
        string gamerInfo = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}", gamer.Name, (int)gamer.Race, (int)gamer.Gender, (int)gamer.Occupation, gamer.Level, gamer.Strength, gamer.Constitution, gamer.Dextirity, gamer.Intelligence, gamer.Wisdom,gamer.MentalStrength,  gamer.Charisma);
        PlayerPrefs.SetString("underworld_character", gamerInfo);
    }
}