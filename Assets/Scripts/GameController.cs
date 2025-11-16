using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Configuração de Tempo")]
    public float tempoMaximo = 30f;      // tempo total em segundos
    private float tempoRestante;
    private bool jogoAtivo = true;

    [Header("Moedas")]
    private int totalMoedas;
    private int moedasColetadas;

    [Header("Referências de Texto 3D")]
    public TMPro.TextMeshPro textoMensagem;      // arrastar no Inspector
    public TMPro.TextMeshPro textoCronometro;    // arrastar no Inspector

    void Awake()
    {
        // Singleton simples
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        tempoRestante = tempoMaximo;

        if (textoMensagem != null)
            textoMensagem.text = "";

        AtualizarCronometro();
    }

    void Update()
    {
        if (!jogoAtivo)
            return;

        tempoRestante -= Time.deltaTime;
        if (tempoRestante < 0f)
            tempoRestante = 0f;

        AtualizarCronometro();

        if (tempoRestante <= 0f)
        {
            Derrota();
        }
    }

    void AtualizarCronometro()
    {
        if (textoCronometro != null)
            textoCronometro.text = $"Tempo: {tempoRestante:0.0}s";
    }

    // Chamado pelo jogador ao iniciar, informando quantas moedas existem
    public void DefinirTotalMoedas(int total)
    {
        totalMoedas = total;
        moedasColetadas = 0;
    }

    // Chamado toda vez que o jogador pega uma moeda
    public void RegistrarColetaMoeda()
    {
        if (!jogoAtivo)
            return;

        moedasColetadas++;

        if (moedasColetadas >= totalMoedas && totalMoedas > 0)
        {
            Vitoria();
        }
    }

    void Vitoria()
    {
        jogoAtivo = false;

        if (textoMensagem != null)
            textoMensagem.text = "Vitória!";

        Debug.Log("🎉 VITÓRIA!");
    }

    void Derrota()
    {
        if (!jogoAtivo)
            return;

        jogoAtivo = false;

        if (textoMensagem != null)
            textoMensagem.text = "Derrota!";

        Debug.Log("💀 DERROTA!");
    }
}
