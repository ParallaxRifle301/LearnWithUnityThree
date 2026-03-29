using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public int money;
    public Transform gunPoint;
    private Animator animator;
    private int atk;
    private float roundSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {

        animator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        animator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));

        this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * roundSpeed * Time.deltaTime);

        if( Input.GetKeyDown(KeyCode.LeftShift) )
        {
            animator.SetLayerWeight(1, 1);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetLayerWeight(1, 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
            animator.SetTrigger("Roll");

        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Fire");
            
    }

    public void InitPlayerInfo(int atk, int money)
    {
        this.atk = atk;
        this.money = money;
        UpdateMoney();
    }


    public void KnifeEvent()
    {

        Collider[] colliders = Physics.OverlapSphere(this.transform.position + this.transform.forward + this.transform.up, 1, 1 << LayerMask.NameToLayer("Monster"));


        GameDataMgr.Instance.PlaySound("Music/Knife");


        for (int i = 0; i < colliders.Length; i++)
        {

            MonsterObject monster = colliders[i].gameObject.GetComponent<MonsterObject>();
            if (monster != null && !monster.isDead)
            {
                monster.Wound(this.atk);
                break;
            }
        }
    }

    public void ShootEvent()
    {

        RaycastHit[] hits = Physics.RaycastAll(new Ray(gunPoint.position, this.transform.forward), 1000, 1 << LayerMask.NameToLayer("Monster"));


        GameDataMgr.Instance.PlaySound("Music/Gun");

        for (int i = 0; i < hits.Length; i++)
        {

            MonsterObject monster = hits[i].collider.gameObject.GetComponent<MonsterObject>();
            if (monster != null && !monster.isDead)
            {

                GameObject effObj = Instantiate(Resources.Load<GameObject>(GameDataMgr.Instance.nowSelRole.hitEff));
                effObj.transform.position = hits[i].point;
                effObj.transform.rotation = Quaternion.LookRotation(hits[i].normal);
                Destroy(effObj, 1);

                monster.Wound(this.atk);
                break;
            }
        }
    }


    public void UpdateMoney()
    {

        UIManager.Instance.GetPanel<GamePanel>().UpdateMoney(money);
    }


    public void AddMoney(int money)
    {
        //加钱
        this.money += money;
        UpdateMoney();
    }
}