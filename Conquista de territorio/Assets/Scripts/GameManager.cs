using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab do bloco
    public GameObject player; // Prefab do jogador
    public int rows = 5; // Número de linhas da matriz
    public int cols = 5; // Número de colunas da matriz
    public float spacing = 1.1f; // Espaçamento entre os blocos

    private Block[,] grid; // Matriz 2D para armazenar os blocos
    private int conqueredTerritories = 0;

    void Start()
    {
        grid = new Block[rows, cols];
        CreateGrid();
    }

    // Método para criar a matriz de blocos
    void CreateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector2 position = new Vector2(col * spacing, row * spacing);
                GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity);
                grid[row, col] = newBlock.GetComponent<Block>();
                grid[row, col].Initialize(row, col, this);
            }
        }

        // Posicionar o jogador no centro do tabuleiro
        Vector2 playerStartPosition = new Vector2((cols / 2) * spacing, (rows / 2) * spacing);
        Instantiate(player, playerStartPosition, Quaternion.identity);
    }

    // Método que é chamado quando um território é conquistado
    public void ConquerTerritory(int row, int col)
    {
        if (!grid[row, col].IsConquered())
        {
            grid[row, col].SetConquered(true);
            conqueredTerritories++;
            Debug.Log("Territórios conquistados: " + conqueredTerritories);
        }
    }

    // Método que retorna a quantidade de territórios conquistados
    public int GetConqueredTerritories()
    {
        return conqueredTerritories;
    }

    // Método que retorna a quantidade de territórios restantes
    public int GetRemainingTerritories()
    {
        return (rows * cols) - conqueredTerritories;
    }
}
