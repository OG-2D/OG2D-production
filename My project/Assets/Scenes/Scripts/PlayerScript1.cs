using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript1 : MonoBehaviour
{
    Rigidbody2D player;
    public float speed;
    public Transform groundCheck;
    bool isGrounded;
    public float jumpForce = 7f;
    new Animator animation;
    int currentHP;
    int maxHP = 3;
    bool isHit = false;
    public Main main;
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Jump();
        CheckGroun();
        if (Input.GetAxis("Horizontal") == 0 && isGrounded && currentHP > 0) //анимация покоя 
            animation.SetInteger("State", 1);
        else
        {
            Flip();
            if (isGrounded && currentHP > 0) //включение анимации бега
                animation.SetInteger("State", 2);
        }
    }

    private void FixedUpdate() => player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y); //бег персонажа
    void Flip() //разварот модельки в сторону бега
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void CheckGroun()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.1f);
        isGrounded = colliders.Length > 1;
        if (!isGrounded && currentHP > 0 && !isHit) //включение анимации прыжка
            animation.SetInteger("State", 3);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //прыжок персонажа
            player.velocity = new Vector2(player.velocity.x, jumpForce);
    }

    public void RecountHP(int deltaHP) // метод перерасчета ХП 
    {
        currentHP += deltaHP; //при уменьшении поступает -1, если сделаем аптечки, то она будет давать +1
        print(currentHP);

        if (deltaHP < 0) //если поступает урон
        {
            //StopCoroutine(OnHit());
            isHit = true;
            //animation.SetInteger("State", 5); Нужно как-то привязать анимацию урона
            StartCoroutine(OnHit()); //включается цикл покраснения
        }
            

        if (currentHP <= 0)
        {
            animation.SetInteger("State", 4);
            player.velocity = Vector2.zero;
            //Destroy(gameObject, 0.65f);
            Invoke(nameof(Lose), 1f);
        }
            
        IEnumerator OnHit() //цикл покраснения персонажа
        {
            GetComponent<SpriteRenderer>().color = isHit ? //если isHit, то краснеет, иначе белеет
                new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.08f, GetComponent<SpriteRenderer>().color.b - 0.08f) :
                new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.08f, GetComponent<SpriteRenderer>().color.b + 0.08f);
            if (GetComponent<SpriteRenderer>().color.g == 1)
                StopCoroutine(OnHit()); // откат краснения
            if (GetComponent<SpriteRenderer>().color.g <= 0)
                isHit = false; //снятие флага
            yield return new WaitForSeconds(0.01f); //ожидание чтобы красный цвет был заметен
            StartCoroutine(OnHit());
        }

    }

    void Lose() => main.GetComponent<Main>().Lose();


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder" && Input.GetAxis("Vertical") != 0)
        {
            isClimbing = true;
            player.bodyType = RigidbodyType2D.Kinematic;
            animation.SetInteger("State", 4);
            transform.Translate(0.5f * Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.up);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isClimbing = false;
            player.bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
