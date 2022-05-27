using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript1 : MonoBehaviour
{
    Rigidbody2D player;
    public float speed;
    public Transform groundCheck;
    bool isGrounded;
    public float jumpForce = 7f;
    new Animator animation;
    int currentHP;
    readonly int maxHP = 3;
    public Main main;
    private bool isClimbing = false;
    public bool leveler = false;
    public Transform deathPointAxisY;
    public SoundsEffector soundsEffector;
    public float DamageTimeSec = 0.2f;
    private SpriteRenderer spriteRend;
    private Color defaultColor;
    public Color DamageColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        currentHP = maxHP;
        spriteRend = GetComponent<SpriteRenderer>();
        defaultColor = spriteRend.color;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Jump();
        CheckGroun();
        if (Input.GetAxis("Horizontal") == 0 && isGrounded && currentHP > 0 && !isClimbing) //анимация покоя 
            animation.SetInteger("State", 1);
        else
        {
            Flip();
            if (isGrounded && currentHP > 0 && !isClimbing) //включение анимации бега
                animation.SetInteger("State", 2);
        }
        if (transform.position.y < deathPointAxisY.position.y)
            RecountHP(-3);
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
        if (!isGrounded && currentHP > 0 && !isClimbing) //включение анимации прыжка
            animation.SetInteger("State", 3);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //прыжок персонажа
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            soundsEffector.PlayJumpSound();
        }   
    }

    public void RecountHP(int deltaHP) // метод перерасчета ХП 
    {
        currentHP += deltaHP; //при уменьшении поступает -1, если сделаем аптечки, то она будет давать +1

        if (deltaHP < 0) //если поступает урон
            StartHitAnimation();

        if (currentHP <= 0)
        {
            animation.SetInteger("State", 4);
            player.velocity = Vector2.zero;
            Invoke(nameof(Lose), 1f);
        }
    }
    
    private IEnumerator OnHit()
    {
        var time = 0f;
        var step = 1f / DamageTimeSec;
        while (time < DamageTimeSec)
        {
            time += Time.deltaTime;
            spriteRend.color = Color.Lerp(DamageColor, defaultColor, step * time);
            yield return null;
        }
    }

    public void StartHitAnimation()
    {
        StopCoroutine(nameof(OnHit));
        StartCoroutine(nameof(OnHit));
    }

    void Lose() => main.GetComponent<Main>().Lose();


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder") && Input.GetAxis("Vertical") != 0)
        {
            isClimbing = true;
            player.bodyType = RigidbodyType2D.Kinematic;
            animation.SetInteger("State", 6);
            transform.Translate(0.5f * Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.up);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isClimbing = false;
            player.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Leveler"))
        {
            collision.gameObject.GetComponent<Leveler>().DownLeveler();
            leveler = true;
        }

        if (collision.gameObject.CompareTag("Door") && leveler)
        {
            collision.gameObject.GetComponent<Door>().UnLock();
            main.GetComponent<Main>().SaveResults();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public int GetHearts() => currentHP;
}

