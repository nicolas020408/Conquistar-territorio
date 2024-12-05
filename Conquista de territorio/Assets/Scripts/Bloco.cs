using UnityEngine;

public class Bloco : Elemento
{
    private bool conquistado = false;
    private SpriteRenderer spriteRenderer;
    private int jogadorDono;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AtualizarCor(Color.white);
    }

    // Sobrescrita do m�todo Interagir da classe base Elemento
    public override void Interagir(GameObject jogador)
    {
        Jogador jogadorScript = jogador.GetComponent<Jogador>();

        // Chama o m�todo AlterarConquista para o jogador conquistar o bloco
        if (!conquistado)
        {
            AlterarConquista(jogadorScript.IsJogador1(), jogadorScript.corDoJogador);
        }
    }

    // M�todo para alterar o estado de conquista do bloco com a cor do jogador
    public void AlterarConquista(bool jogador1, Color corDoJogador)
    {
        conquistado = true;
        AtualizarCor(corDoJogador);
        jogadorDono = jogador1 ? 1 : 2;
        GameManager.instance.ConquistarTerritorio();
    }

    // M�todo para verificar se o bloco foi conquistado
    public bool PegarConquistado() => conquistado;

    public int PegarJogadorDono() => jogadorDono;

    // M�todo que muda a cor do bloco dependendo se ele foi conquistado ou n�o
    private void AtualizarCor(Color novaCor)
    {
        spriteRenderer.color = novaCor;
    }
}

