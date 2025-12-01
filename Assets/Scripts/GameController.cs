using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    public TextMeshPro textoMensagem;      // texto grande de vitória/derrota
    public TextMeshPro textoCronometro;    // texto do tempo
    public TextMeshPro textoMoedas;        // texto "Moedas: X/Y"
    public TextMeshPro textoReiniciar;     // texto "(Aperte R para reiniciar)"

    // Permite que outros scripts saibam se o jogo ainda está rolando
    public bool JogoAtivo => jogoAtivo;

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

        // 🔴 IMPORTANTE: começa escondido
        if (textoReiniciar != null)
        {
            textoReiniciar.text = "";                 // limpa texto
            textoReiniciar.gameObject.SetActive(false); // esconde objeto
        }

        AtualizarCronometro();
        AtualizarTextoMoedas();
    }

    void Update()
    {
        // Se o jogo acabou, só deixamos a tecla R funcionar
        if (!jogoAtivo)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene cena = SceneManager.GetActiveScene();
                SceneManager.LoadScene(cena.name);
            }
            return;
        }

        // Contagem regressiva de tempo enquanto o jogo está ativo
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

    void AtualizarTextoMoedas()
    {
        if (textoMoedas != null)
            textoMoedas.text = $"Moedas: {moedasColetadas}/{totalMoedas}";
    }

    // Chamado pelo jogador ao iniciar, informando quantas moedas existem
    public void DefinirTotalMoedas(int total)
    {
        totalMoedas = total;
        moedasColetadas = 0;
        AtualizarTextoMoedas();
    }

    // Chamado toda vez que o jogador pega uma moeda
    public void RegistrarColetaMoeda()
    {
        if (!jogoAtivo)
            return;

        moedasColetadas++;
        AtualizarTextoMoedas();

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

        if (textoReiniciar != null)
        {
            textoReiniciar.gameObject.SetActive(true);            // mostra
            textoReiniciar.text = "(Aperte R para reiniciar)";    // define texto
        }

        Debug.Log("🎉 VITÓRIA!");
    }

    void Derrota()
    {
        if (!jogoAtivo)
            return;

        jogoAtivo = false;

        if (textoMensagem != null)
            textoMensagem.text = "Derrota!";

        if (textoReiniciar != null)
        {
            textoReiniciar.gameObject.SetActive(true);            // mostra
            textoReiniciar.text = "(Aperte R para reiniciar)";
        }

        Debug.Log("💀 DERROTA!");
    }
}
