using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 screenBoundery;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 700f;
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gun;
    
    float targetAngle;
    [SerializeField] public float health = 5f;
    [SerializeField] float InvulnerabilityDur = 2f;
    float invulnerableUntil;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBoundery = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        FindAnyObjectByType<HealthManager>()?.RefreshHealthBar();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack()
    {
       Rigidbody2D playerBullet = Instantiate(bullet, gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
       playerBullet.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        if (moveInput != Vector2.zero)
        {
            targetAngle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundery.x, screenBoundery.x)
                                        ,Mathf.Clamp(transform.position.y, -screenBoundery.y, screenBoundery.y));

    }

    void FixedUpdate()
    {
        float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngle - 90f, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemies") && Time.time >= invulnerableUntil)
        {
            health -= 1;
            invulnerableUntil = Time.time + InvulnerabilityDur;
            FindAnyObjectByType<HealthManager>()?.RefreshHealthBar();

            if(collision.gameObject.CompareTag("Enemies"))
            {
                Destroy(collision.gameObject);
            }

            if(health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Game Over");
            }
        }
        
    }
}
