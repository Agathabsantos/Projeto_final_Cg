using UnityEngine;

public class CriarParedesDoPlano : MonoBehaviour
{
    public float alturaParede = 7f;
    public float espessuraParede = 1f;
    public float margemInterna = 3f; // distância da borda REAL até a parede

    void Start()
    {
        // Pegamos o tamanho real do plano
        Vector3 tamanhoPlano = GetComponent<Renderer>().bounds.size;

        float largura = tamanhoPlano.x;
        float profundidade = tamanhoPlano.z;

        // Criar container para organização
        GameObject container = new GameObject("Paredes");
        container.transform.parent = transform;
        container.transform.localPosition = Vector3.zero;

        // Calculamos metade dos tamanhos
        float halfX = largura / 2f - margemInterna;
        float halfZ = profundidade / 2f - margemInterna;

        // Criar todas as paredes com margem aplicada
        CriarParede("Parede_Norte", container.transform,
            new Vector3(0, alturaParede / 2, halfZ),
            new Vector3(largura - (margemInterna * 2), alturaParede, espessuraParede));

        CriarParede("Parede_Sul", container.transform,
            new Vector3(0, alturaParede / 2, -halfZ),
            new Vector3(largura - (margemInterna * 2), alturaParede, espessuraParede));

        CriarParede("Parede_Leste", container.transform,
            new Vector3(halfX, alturaParede / 2, 0),
            new Vector3(espessuraParede, alturaParede, profundidade - (margemInterna * 2)));

        CriarParede("Parede_Oeste", container.transform,
            new Vector3(-halfX, alturaParede / 2, 0),
            new Vector3(espessuraParede, alturaParede, profundidade - (margemInterna * 2)));

        Debug.Log("✅ Paredes com MARGEM criadas!");
    }

    void CriarParede(string nome, Transform pai, Vector3 pos, Vector3 escala)
    {
        GameObject parede = GameObject.CreatePrimitive(PrimitiveType.Cube);
        parede.name = nome;
        parede.transform.parent = pai;
        parede.transform.localPosition = pos;
        parede.transform.localScale = escala;

        // invisível mas colide
        Destroy(parede.GetComponent<Renderer>());
    }
}
