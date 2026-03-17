using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance;

    public static GameDataMgr Instance
    {
        get
        {
            if (instance == null)
                instance = new GameDataMgr();
            return instance;
        }
    }

    public RoleInfo nowSelRole;
    public MusicData musicData;
    public PlayerData playerData;
    public List<RoleInfo> roleInfoList;
    public List<SceneInfo> sceneInfoList;

    private GameDataMgr()
    {
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
        playerData = JsonMgr.Instance.LoadData<PlayerData>("PlayerData");
        roleInfoList = JsonMgr.Instance.LoadData<List<RoleInfo>>("RoleInfo");
        sceneInfoList = JsonMgr.Instance.LoadData<List<SceneInfo>>("SceneInfo");
    }
    

    public void SaveMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
        
    }
    public void SavePlayerData()
    {
        JsonMgr.Instance.SaveData(playerData, "PlayerData");
    }
}
