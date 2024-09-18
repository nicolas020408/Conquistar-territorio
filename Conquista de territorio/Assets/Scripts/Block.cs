using UnityEngine;

public class Block : MonoBehaviour
{
    private bool conquered = false; // O bloco foi conquistado?
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    private int row, col;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    // Método para inicializar o bloco com suas coordenadas e referência ao GameController
    public void Initialize(int row, int col, GameManager manager)
    {
        this.row = row;
        this.col = col;
        this.gameManager = manager;
    }

    // Método para alterar o estado de conquista do bloco
    public void SetConquered(bool conquered)
    {
        this.conquered = conquered;
        UpdateColor();
    }

    // Método para verificar se o bloco foi conquistado
    public bool IsConquered()
    {
        return conquered;
    }

    // Método que muda a cor do bloco dependendo se ele foi conquistado ou não
    private void UpdateColor()
    {
        if (conquered)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    // Detectar o clique no bloco
    void OnMouseDown()
    {
        gameManager.ConquerTerritory(row, col);
    }
}
