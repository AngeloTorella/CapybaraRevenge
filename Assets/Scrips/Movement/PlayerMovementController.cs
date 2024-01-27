using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float playerJumpForce;
    [SerializeField] private float playerWallJumpForce;
    [SerializeField] private float rollForce;
    [SerializeField] private float rollDuration;
    [SerializeField] private float rollDelay;

    [SerializeField] private LayerMask grounLayer;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private Transform grounSensorT;
    [SerializeField] private Transform wallSensorT;

    [SerializeField] private IAnimationController animationController;
    

    [SerializeField] private float largo = 1.0f;
    [SerializeField] private float ancho = 1.0f;
    private Collider2D playerCollider2D;

    private SaveManager saveManager;
    [SerializeField] private GameObject playerPrefab;
    private Rigidbody2D     rb2D;
    private SpriteRenderer  spriteRenderer;

    private int     direccion;
    private float   inputX;

    private bool isWalled;
    private bool isGrounded;
    private bool isWallJumping;
    private bool isRolling;
    private bool isRollable;

    private float speed;

    private bool isSave;
    private bool isLoad;

    private bool isDamage;


    public void Awake()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.animationController = GetComponent<IAnimationController>();
        
        this.saveManager = FindObjectOfType<SaveManager>();
        this.playerCollider2D = GetComponent<Collider2D>();

        this.isGrounded = true;
        this.isWalled = true;
        this.isWallJumping = false;
        this.isRolling = false;
        this.isRollable = true;

        this.direccion = 1;
        // Asegúrate de que el collider esté habilitado
        if (this.playerCollider2D != null)
        {
            this.playerCollider2D.enabled = true;
        }
        else
        {
            Debug.LogError("No Collider2D component found on this GameObject.");
        }
    }
    void Start()
    {
        
        // Guarda la posición actual del jugador y el prefab del jugador
        saveManager.SaveGame(transform.position);
    }

    void FixedUpdate()
    {
        //Actualiza el estado del booleano isGrouded cada frame
        isGrounded = Physics2D.OverlapBox(grounSensorT.position, new Vector3(largo, ancho, 0), 0f, grounLayer);
        Debug.Log("ground: " + isGrounded.ToString());

        //actualizar la posicion del sendor en base al input x cada frame
        wallSensorT.position = new Vector2(transform.position.x + direccion, transform.position.y);

        //actualiza el estado del booleano isWalled cada frame
        isWalled = Physics2D.OverlapCircle(wallSensorT.position, 0.1f, wallLayer);
        Debug.Log("wall: " + isWalled.ToString());

        speed = playerMoveSpeed;
        if (rb2D.velocity.y < -0.1f)
        {
            //cambiar la velociadad de speed a .5 playerspeed
            speed = playerMoveSpeed * .7f;
        }

    }

    void Update()
    {
        animationController.Roll(isRolling);

        if (isRolling)
            return;

        animationController.Wall(isWalled);

        if (isWallJumping)
            return;

        animationController.Jump(Mathf.Round(rb2D.velocity.y * 100) / 100);
        animationController.Run(Mathf.Abs(Mathf.Round(rb2D.velocity.x * 100) / 100));

        inputX = Input.GetAxis("Horizontal");

        //actualizar la direcion
        if (inputX > 0)
        {
            direccion = 1;
        }
        else if (inputX < 0)
        {
            direccion = -1;
        }

        //actualizar direccion sprite
        if (direccion == 1)
        {
            spriteRenderer.flipX = true;
        }
        else if (direccion == -1)
        {
            spriteRenderer.flipX = false;
        }

        //Movimiento horizontal
        rb2D.velocity = new Vector2(inputX * speed, rb2D.velocity.y);

        // Salto
        if (Input.GetButtonDown("Jump") && !isRolling)
        {
            if (isGrounded)
            {
                rb2D.AddForce(new Vector2(0.0f, playerJumpForce), ForceMode2D.Impulse);
            }
            else if (isWalled)
            {
                animationController.Wall(isWalled);
                isWallJumping = true;
                StartCoroutine(WallJump());
            }
        }

        //Roll

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && isRollable)
        {
            isRolling = true;
            isRollable = false;
            StartCoroutine(Roll());
        }

        // Save
        if (isSave && Input.GetKeyDown(KeyCode.E))
        {
            animationController.Save(true);
            StartCoroutine(Save());
        }
        else
        {
            animationController.Save(false);
        }

        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SavePoint"))
        {
            isSave = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SavePoint"))
        {
            isSave = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDamage = true;
            animationController.Damage(true);

            // Inicia la coroutine para manejar la muerte del jugador
            StartCoroutine(Damage());
        }
        else 
        {
            isDamage = false;
            animationController.Damage(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(grounSensorT.position, new Vector2(largo, ancho));
        Gizmos.DrawWireSphere(wallSensorT.position, 0.1f);
    }

    IEnumerator WallJump()
    {
        inputX *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        rb2D.velocity = new Vector2(playerWallJumpForce * direccion * -1, playerJumpForce);
        //esperar hasta que la velocidad en y sea menor a 0.1
        yield return new WaitUntil(() => rb2D.velocity.y < -0.1f);
        isWallJumping = false;
    }

    IEnumerator Roll()
    {
        rb2D.velocity = new Vector2(rollForce * direccion, 0.0f);
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
        yield return new WaitForSeconds(rollDelay);
        isRollable = true ;
    }

    IEnumerator Save()
    {
        Debug.Log("Guardando...");

        // Guarda la posición actual del jugador y el prefab del jugador
        saveManager.SaveGame(transform.position);
        // Espera a que la animación de guardado termine
        yield return new WaitForSeconds(2f);

        isSave = false;
    }

    private void Die()
    {
        // Destruye el jugador
        Destroy(gameObject);

        // Recrea el jugador en la última posición guardada
        Vector2 lastSavedPosition = saveManager.LoadGame();
        PlayerMovementController newPlayer = Instantiate(playerPrefab, lastSavedPosition, Quaternion.identity).GetComponent<PlayerMovementController>();
    }

    IEnumerator Damage()
    {
        // Espera un segundo para que la animación de daño se complete
        yield return new WaitForSeconds(.5f);

        isDamage = false;
        animationController.Damage(false);

        // Llama a la función Die
        Die();
    }
}