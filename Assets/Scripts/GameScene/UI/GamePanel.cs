using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    public Image imgHP;
    public Text txtHP;
    public Text txtWave;
    public Text txtMoney;
    public float hpW = 500;
    public Button btnQuit;
    public Transform botTrans;
    public List<TowerBtn> towerBtns = new List<TowerBtn>();
    private TowerPoint nowSelTowerPoint;
    private bool checkInput;

    public override void Init()
    {
        btnQuit.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<GamePanel>();
            SceneManager.LoadScene("BeginScene");

        });
        botTrans.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void UpdateTowerHp(int hp, int maxHP)
    {
        txtHP.text = hp + "/" + maxHP;
        (imgHP.transform as RectTransform).sizeDelta = new Vector2((float)hp / maxHP * hpW, 38);
    }
    public void UpdateWaveNum(int nowNum, int maxNum)
    {
        txtWave.text = nowNum + "/" + maxNum;
    }
    public void UpdateMoney(int money)
    {
        txtMoney.text = money.ToString();
    }
    public void UpdateSelTower(TowerPoint point)
    {
        nowSelTowerPoint = point;
        if (nowSelTowerPoint == null)
        {
            checkInput = false;
            botTrans.gameObject.SetActive(false);
        }
        else
        {
            checkInput = true;
            botTrans.gameObject.SetActive(true);
            if (nowSelTowerPoint.nowTowerInfo == null)
            {
                for (int i = 0; i < towerBtns.Count; i++)
                {
                    towerBtns[i].gameObject.SetActive(true);
                    towerBtns[i].InitInfo(nowSelTowerPoint.chooseIDs[i], "数字键" + (i + 1));
                }
            }
            else
            {
                for (int i = 0; i < towerBtns.Count; i++)
                {
                    towerBtns[i].gameObject.SetActive(false);
                }
                towerBtns[1].gameObject.SetActive(true);
                towerBtns[1].InitInfo(nowSelTowerPoint.nowTowerInfo.nextLev, "空格键");
            }
        }

    }
    protected override void Update()
    {
        base.Update();
        if (!checkInput)
            return;
        if (nowSelTowerPoint.nowTowerInfo == null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.chooseIDs[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.chooseIDs[1]);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.chooseIDs[2]);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                nowSelTowerPoint.CreateTower(nowSelTowerPoint.nowTowerInfo.nextLev);
            }
        }
    }
}
