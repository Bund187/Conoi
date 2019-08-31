using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject inventory, exclamation, pressEnter, blur;
    public InventoryNavigation inventoryNavigationScript;
    public ScreenManager screenManagerScript;
    public Sprite gameOverImg1, gameOverImg2;

    Rigidbody2D rb;
    Animator anim, exclamationAnim;
    bool isMoving, canMove, inventoryOn;
    SpriteRenderer sRender;
   
    void Start () {
       
        exclamationAnim = exclamation.GetComponent<Animator>();
        rb =GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sRender = GetComponent<SpriteRenderer>();
        inventoryOn = false;
        canMove = true;
    }
	
	void FixedUpdate () {
       
        if(!inventory.activeSelf && !anim.GetBool("isDead"))
            Move();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ToggleInventory();

        if (anim.GetBool("isDead"))
        {
            if (Utils.AnimationIsFinished(anim))
            {
                Color color = new Color();
                screenManagerScript.ShowScreen(gameOverImg1, gameOverImg2, color);
            }
        }
    }

    public void ToggleInventory()
    {
        anim.SetBool("isMoving", false);
        inventoryOn = !inventoryOn;
        inventory.SetActive(inventoryOn);
        blur.SetActive(inventoryOn);
        if (exclamation.activeSelf && inventory.transform.childCount > 0)
        {
            pressEnter.SetActive(inventoryOn);
        }
    }

    void Move()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal>0)
        {
            Acceleration();
            isMoving = true;
            sRender.flipX = false;
        }
        else if (horizontal < 0)
        {
            Acceleration();
            isMoving = true;
            sRender.flipX = true;
        }
        else if(vertical > 0 || vertical < 0)
        {
            Acceleration();
            isMoving = true;
        }
        else
        {
            if (speed > 0)
                speed -= 0.001f;
            else
                speed = 0;
            
            isMoving = false;
        }
        anim.SetBool("isMoving", isMoving);
        
        Vector2 moving = new Vector2(horizontal, vertical);
        transform.Translate(moving *speed);
    }

    void Acceleration()
    {
        if (speed < 0.03f)
        {
            speed += 0.003f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "NPC")
        {
            inventoryNavigationScript.Npc = collision.gameObject;
            exclamation.SetActive(true);
            exclamationAnim.SetBool("out", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "NPC")
        {
            exclamationAnim.SetBool("out", true);
            exclamation.SetActive(false);
            pressEnter.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead")
        {
            anim.SetBool("isDead", true);
        }
    }
}
