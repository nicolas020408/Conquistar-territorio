using UnityEngine;

// Classe base para jogadores
public class JogadorBase : MonoBehaviour
{
    protected float velocidade = 5f;
    protected Vector2 direcao;

    // Método virtual para movimento
    public virtual void Mover()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}

