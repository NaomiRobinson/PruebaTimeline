using UnityEngine;
using UnityEngine.InputSystem;

public class PjMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float salto = 12f;

    private Rigidbody2D rb;
    private float inputHorizontal;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    public void OnMove(InputValue value)
    {

        Vector2 direccion = value.Get<Vector2>();
        inputHorizontal = direccion.x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, salto);
        }
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(inputHorizontal * velocidad, rb.linearVelocity.y);
    }

    public void SincronizarTransform()
    {
        rb.position = transform.position;
        rb.linearVelocity = Vector2.zero;
        inputHorizontal = 0;
    }
}