using UnityEngine;

public class ColetarDiamantes : MonoBehaviour
{
  [SerializeField]private int diamantesColetados;

private void OnControllerColliderHit(ControllerColliderHit hit) {
    //método chamado automaticamente pela Unity é ativado ao colidir com outro objeto com o ColliderRidg
    if(hit.gameObject.tag == "Diamante"){
            diamantesColetados++;
            Destroy(hit.gameObject);
        }
  }
}
