using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;

    void Update()
    {
        // Movimento baseado nas teclas de seta ou WASD
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se o jogador colidir com um bloco, ele conquista o território
        if (other.CompareTag("Block"))
        {
            Block block = other.GetComponent<Block>();
            if (!block.IsConquered())
            {
                block.SetConquered(true);
            }
        }
    }
}
