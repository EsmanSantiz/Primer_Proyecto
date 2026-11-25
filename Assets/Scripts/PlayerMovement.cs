using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Velocidad de movimiento horizontal
    [SerializeField] private float jumpForce = 7f; // Fuerza del salto
    private Rigidbody2D body; // Referencia al componente Rigidbody2D

    // Awake se llama cuando se carga la instancia del script
    void Awake()
    {
        body = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D adjunto al jugador
    }

    // Update se llama una vez por frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Obtiene la entrada horizontal (A/D o flechas)
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y); // Aplica velocidad horizontal

        // Voltea el personaje según la dirección de movimiento
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Salto al presionar la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }
}