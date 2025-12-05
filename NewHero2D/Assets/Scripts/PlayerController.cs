using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    Rigidbody2D rb;
    Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Aim toward mouse
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorld - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}
