using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    public Button btnStart;

    public Button btnSetting;

    public Button btnAbout;

    public Button btnQuit;
    
    public override void Init()
    {
        btnStart.onClick.AddListener(() =>
        {
            
        });
        btnSetting.onClick.AddListener(() =>
        {
            
        });
        btnAbout.onClick.AddListener(() =>
        {
            
        });
        btnQuit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    
}
