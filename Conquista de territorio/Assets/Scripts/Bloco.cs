using UnityEngine;

public class Bloco : MonoBehaviour
{
    private bool conquistado = false; // O bloco foi conquistado?
    private SpriteRenderer spriteRenderer;
    private int jogadorDono;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AtualizarCor(Color.white);
    }

    // Método para alterar o estado de conquista do bloco com a cor do jogador
    public void AlterarConquista(bool jogador1, Color corDoJogador)
    {
        conquistado = true;
        AtualizarCor(corDoJogador);

        // Notifica o GameController que o bloco foi conquistado por um jogador
        if (jogador1)
        {
            jogadorDono = 1;
            GameManager.instance.ConquistarTerritorio();
        }
        else
        {
            jogadorDono = 2;
            GameManager.instance.ConquistarTerritorio();
        }
    }

    // Método para verificar se o bloco foi conquistado
    public bool PegarConquistado()
    {
        return conquistado;
    }

    public int PegarJogadorDono()
    {
        return jogadorDono;
    }

    // Método que muda a cor do bloco dependendo se ele foi conquistado ou não
    private void AtualizarCor(Color novaCor)
    {
        spriteRenderer.color = novaCor;
    }
}
