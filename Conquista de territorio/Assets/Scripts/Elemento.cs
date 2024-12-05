using UnityEngine;

public class Elemento : MonoBehaviour
{
    // Método virtual que pode ser sobrescrito pelas subclasses
    public virtual void Interagir(GameObject jogador)
    {
        Debug.Log("Interação padrão com o jogador");
    }
}

