using UnityEngine;

// Este script controla o movimento de um personagem em um jogo 3D
// Ele faz 3 coisas principais:
// 1. Move o personagem baseado nas teclas que o jogador pressiona
// 2. Aplica gravidade para o personagem não flutuar
// 3. Faz o personagem olhar para a direção que está andando
public class NewMonoBehaviourScript : MonoBehaviour
{
    // ========== VARIÁVEIS (onde guardamos informações) ==========
    
    // CharacterController: é como se fosse o "motor" que move o personagem
    // Pense nele como um motorista invisível que obedece nossos comandos
    private CharacterController characterController;
    
    // Gravidade: força que puxa o personagem para baixo (igual na vida real)
    // -9.81 é a velocidade da gravidade na Terra em metros por segundo
    // Só afeta o eixo Y (altura), por isso X=0 e Z=0
    private Vector3 gravidade = new Vector3(0, -9.81f, 0);
    
    // Velocidade: quão rápido o personagem anda
    // [SerializeField] permite que você ajuste esse valor no editor do Unity
    // sem precisar reescrever o código toda vez
    [SerializeField] private float velocidade;
    
    // Animator: controla as animações do personagem (andar, parar, pular, etc)
    // É como um diretor de cinema que diz qual animação tocar
    private Animator animator;
    
    
    // ========== START: Executa UMA VEZ quando o jogo começa ==========
    void Start()
    {
        // GetComponent é como procurar uma peça específica no personagem
        // Aqui estamos "pegando" o CharacterController que está anexado ao mesmo objeto
        characterController = GetComponent<CharacterController>();
        
        // Pegamos também o Animator para controlar animações depois
        animator = GetComponent<Animator>();
    }

    
    // ========== UPDATE: Executa CONTINUAMENTE (a cada frame do jogo) ==========
    // Frame = uma "foto" do jogo. Jogos mostram 30-60+ fotos por segundo
    // criando a ilusão de movimento (como um filme)
    void Update()
    {
        // ---------- PASSO 1: CAPTURAR A ENTRADA DO JOGADOR ----------
        
        // Input.GetAxis captura o que o jogador está apertando:
        // "Horizontal": teclas A/D ou Setas Esquerda/Direita
        //   - Retorna -1 (esquerda), 0 (nada) ou 1 (direita)
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        
        // "Vertical": teclas W/S ou Setas Cima/Baixo
        //   - Retorna -1 (para trás), 0 (nada) ou 1 (para frente)
        float movimentoVertical = Input.GetAxis("Vertical");
       
        
        // ---------- PASSO 2: CRIAR UM VETOR DE MOVIMENTO ----------
        
        // Vector3 é como uma seta que aponta em uma direção no espaço 3D
        // Tem 3 valores: X (direita/esquerda), Y (cima/baixo), Z (frente/trás)
        // Aqui criamos uma seta que aponta para onde o jogador quer ir
        // Y = 0 porque não queremos que apertar W faça o personagem voar
        Vector3 movimento = new Vector3(movimentoHorizontal, 0, movimentoVertical);
        
        
        // ---------- PASSO 3: MOVER O PERSONAGEM ----------
        
        // characterController.Move() é o comando que efetivamente move o personagem
        // Vamos entender cada parte:
        
        // movimento.normalized: transforma a seta em uma seta de tamanho 1
        //   - Isso impede que andar na diagonal seja mais rápido
        //   - Exemplo: se apertar W+D juntos, sem normalize seria 1.4x mais rápido
        
        // Time.deltaTime: tempo que passou desde o último frame (geralmente 0.016s)
        //   - Isso garante movimento suave independente da velocidade do computador
        //   - Computador rápido (60 fps) = passos pequenos e frequentes
        //   - Computador lento (30 fps) = passos maiores e menos frequentes
        //   - Resultado final: mesma velocidade em qualquer PC
        
        // velocidade: nossa variável que define quão rápido o personagem anda
        characterController.Move(movimento.normalized * Time.deltaTime * velocidade);
        
        // Aplicar gravidade separadamente
        // Isso puxa o personagem para baixo constantemente
        // Sem isso, o personagem flutuaria no ar
        characterController.Move(gravidade * Time.deltaTime);

        
        // ---------- PASSO 4: ROTACIONAR O PERSONAGEM ----------
        
        // Só rotaciona se o personagem estiver se movendo
        // Vector3.zero significa "sem movimento" (0, 0, 0)
        if (movimento != Vector3.zero)
        {
            // Quaternion.LookRotation: calcula a rotação necessária para
            // o personagem olhar na direção do movimento
            // Pense nisso como: "vire o personagem para onde ele está andando"
            Quaternion rotacaoAlvo = Quaternion.LookRotation(movimento);
            
            // Quaternion.Slerp: faz uma rotação SUAVE (não instantânea)
            // Slerp = "Spherical Linear Interpolation" (interpolação esférica)
            // É como girar o volante de um carro gradualmente, não de uma vez
            //
            // Parâmetros:
            // - transform.rotation: rotação atual do personagem
            // - rotacaoAlvo: para onde queremos que ele olhe
            // - Time.deltaTime * 10f: velocidade da rotação
            //   - 10f = multiplicador (quanto maior, mais rápido vira)
            //   - Time.deltaTime garante que gira na mesma velocidade em qualquer PC
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * 10f);
        }

        
        // ---------- PASSO 5: CONTROLAR ANIMAÇÃO ----------
        
        // animator.SetBool: ativa ou desativa um parâmetro booleano (verdadeiro/falso)
        // no Animator Controller
        //
        // "Andar": nome do parâmetro no Animator
        // movimento != Vector3.zero: 
        //   - Se está se movendo = true (toca animação de andar)
        //   - Se está parado = false (toca animação de idle/parado)
        animator.SetBool("Andar", movimento != Vector3.zero);
    }
}
