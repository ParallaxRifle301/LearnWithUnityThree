using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public Animator  animator;
    private int atk;

    public int money;

    private float roundSpeed = 50;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void InitPlayer(int atk, int money)
    {
        this.atk= atk;
        this.money = money;
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        animator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));
        this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * roundSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetLayerWeight(1, 1);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetLayerWeight(1, 0); 
        }
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetTrigger("Roll");
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Fire");
        }
        
        
    }
}
