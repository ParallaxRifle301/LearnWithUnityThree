using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GamePanel:BasePanel
    {
        public Image imgHP;
        public Text txtHP;
        public Text txtWave;
        public Text txtMoney;
        public float hpW = 500;
        public Button btnQuit;
        public Transform botTrans;
        public List<TowerBtn> btnList=new List<TowerBtn>();
        public override void Init()
        {
            btnQuit.onClick.AddListener(() =>
            {
                UIManager.Instance.HidePanel<GamePanel>();
                SceneManager.LoadScene("BeginScene");
                });
        
            botTrans.gameObject.SetActive(false);
        }
        public void UpdateTowerHp(int hp,int maxHP)
        {
            txtHP.text = hp + "/" + maxHP;
            (imgHP.transform as RectTransform).sizeDelta = new Vector2((float)hp/maxHP*hpW,38);

        }
        public void UpdateWaveNum(int nowNum,int maxNum)
        {
            txtWave.text=nowNum+"/"+maxNum;
        }

        public void UpdateMoney(int money)
        {
            txtMoney.text = money.ToString();
        }
    }
}