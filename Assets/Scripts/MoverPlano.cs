using UnityEngine;

public class MoverPlano : MonoBehaviour
{
    public float velocidadeRotacao = 30f;
    public float anguloMaximo = 25f;

    void Update()
    {
        // Se o jogo acabou, não mexe mais o plano
        if (GameController.Instance != null && !GameController.Instance.JogoAtivo)
            return;

        // W/S ou setas ↑/↓
        float vertical = Input.GetAxis("Vertical");
        // A/D ou setas ←/→
        float horizontal = Input.GetAxis("Horizontal");

        // Pega os ângulos atuais do plano (em graus)
        Vector3 euler = transform.localEulerAngles;

        // Converte de 0..360 para -180..180 (fica mais fácil de limitar)
        float rotX = NormalizarAngulo(euler.x);
        float rotZ = NormalizarAngulo(euler.z);

        // Aplica o input
        rotX += vertical * velocidadeRotacao * Time.deltaTime;
        rotZ += -horizontal * velocidadeRotacao * Time.deltaTime;

        // Limita o quanto pode inclinar pra cada lado
        rotX = Mathf.Clamp(rotX, -anguloMaximo, anguloMaximo);
        rotZ = Mathf.Clamp(rotZ, -anguloMaximo, anguloMaximo);

        // Aplica de volta a rotação limitada (mantém Y = 0)
        transform.localRotation = Quaternion.Euler(rotX, 0f, rotZ);
    }

    // Converte 0..360 em -180..180
    float NormalizarAngulo(float angulo)
    {
        if (angulo > 180f)
            angulo -= 360f;
        return angulo;
    }
}
