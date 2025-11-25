using UnityEngine;

/// <summary>
/// Controla o movimento, rotação e animações de um personagem em 3D.
/// </summary>
public class MovimentoPersonagem : MonoBehaviour
{
    // ========== CONFIGURAÇÕES ==========
    [Header("Configurações de Movimento")]
    [SerializeField] private float velocidadeMovimento = 5f;
    [SerializeField] private float velocidadeRotacao = 10f;

    [Header("Física")]
    [SerializeField] private float forcaGravidade = -9.81f;

    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioClip[] passosAudioClips;

    // ========== COMPONENTES ==========
    private CharacterController characterController;
    private Animator animator;
    
    // ========== CACHE DE ANIMAÇÃO ==========
    private int animacaoAndarHash;
    
    // ========== INICIALIZAÇÃO ==========
    void Start()
    {
        // Pega os componentes anexados ao personagem
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
        // Cacheia o hash da animação para melhor performance
        animacaoAndarHash = Animator.StringToHash("Andar");
        
        // Validação: avisa se algo está faltando
        if (characterController == null)
        {
            Debug.LogError("CharacterController não encontrado! Adicione um ao personagem.");
        }
        
        if (animator == null)
        {
            Debug.LogWarning("Animator não encontrado. Animações não funcionarão.");
        }
    }

    // ========== LOOP PRINCIPAL ==========
    void Update()
    {
        ProcessarMovimento();
        AplicarGravidade();
    }
    
    // ========== MOVIMENTO ==========
    /// <summary>
    /// Processa entrada do jogador e movimenta o personagem
    /// </summary>
    private void ProcessarMovimento()
    {
        // Captura entrada do jogador (WASD ou Setas)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Cria vetor de direção do movimento
        Vector3 direcaoMovimento = new Vector3(horizontal, 0f, vertical);
        
        // Normaliza para evitar movimento mais rápido na diagonal
        direcaoMovimento = direcaoMovimento.normalized;
        
        // Verifica se está se movendo
        bool estaMovendo = direcaoMovimento.magnitude > 0.01f;
        
        if (estaMovendo)
        {
            // Move o personagem
            Vector3 movimento = direcaoMovimento * velocidadeMovimento * Time.deltaTime;
            characterController.Move(movimento);
            
            // Rotaciona o personagem para a direção do movimento
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcaoMovimento);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                rotacaoAlvo, 
                velocidadeRotacao * Time.deltaTime
            );
        }
        
        // Atualiza animação
        if (animator != null)
        {
            animator.SetBool(animacaoAndarHash, estaMovendo);
        }
    }
    
    // ========== FÍSICA ==========
    /// <summary>
    /// Aplica gravidade ao personagem
    /// </summary>
    private void AplicarGravidade()
    {
        // Cria vetor de gravidade
        Vector3 gravidade = new Vector3(0f, forcaGravidade, 0f);
        
        // Aplica gravidade
        characterController.Move(gravidade * Time.deltaTime);
    }

    private void OnPassos()
    {
        int index = Random.Range(0, passosAudioClips.Length);
        passosAudioSource.PlayOneShot(passosAudioClips[index]);
    }
}