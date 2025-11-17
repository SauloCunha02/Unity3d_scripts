using UnityEngine;

public class ColetarDiamantes : MonoBehaviour
{
  [SerializeField]private int diamantesColetados;
  [SerializeField]private JogadorUI jogadorUI;

private void OnControllerColliderHit(ControllerColliderHit hit) {
    //método chamado automaticamente pela Unity é ativado ao colidir com outro objeto com o ColliderRidg
    if(hit.gameObject.tag == "Diamante"){
            diamantesColetados++;
            jogadorUI.AtualizarDiamantesColetados(diamantesColetados, 5 );
            Destroy(hit.gameObject);
        }
  }
}
