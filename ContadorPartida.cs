using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   private float contador;
 [SerializeField]private JogadorUI jogadorUI;
    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        jogadorUI.AtualizarContador(contador);
    }
}
