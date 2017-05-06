using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Texture pointer;
    public GUISkin customSkin;
    public float leftOffset;
    public float topOffset;
    public float buttonWidth;
    public float buttonHeight;
    public float offset;

    void Start()
    {
        buttonWidth = 140;
        buttonHeight = 25;
        offset = 5;

        leftOffset = (Screen.width - buttonWidth) / 2;
        topOffset = 100;
    }


    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin=customSkin;
        if (GUI.Button(new Rect(leftOffset, topOffset, buttonWidth, buttonHeight), "New Game")) Application.LoadLevel(1);
        if (GUI.Button(new Rect(leftOffset, buttonHeight + topOffset + offset, buttonWidth, buttonHeight), "Continue")) Application.LoadLevel(2);
        if (GUI.Button(new Rect(leftOffset, buttonHeight * 2 + topOffset + offset, buttonWidth, buttonHeight), "Exit")) Application.Quit();

        GUI.TextArea(new Rect((Screen.width - 400) / 2, buttonHeight * 4 + topOffset, 400, 250), "Game controllers \r\n\r\nW, Up - move forward.\r\nA, Left - left rotation.\r\nD, Right - right rotation.\r\nS, Down - move backward.\r\nPressedShift+(W, Up or S, Down) - run forward or backward.\r\nLeftMouse - select target.\r\nRightMouse + Mouse orbit - rotate game camera.");
    }
}
