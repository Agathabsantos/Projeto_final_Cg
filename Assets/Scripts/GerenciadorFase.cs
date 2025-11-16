using UnityEngine;

public class GerenciadorFase : MonoBehaviour
{
    [Header("Referências")]
    public Transform plano;
    public GameObject moedaPrefab;

    [Header("Moedas")]
    public int quantidadeMoedas = 5;
    public float alturaMoeda = 0.6f;
    public float margemBorda = 1f;

    void Start()
    {
        if (plano == null || moedaPrefab == null)
        {
            Debug.LogError("GerenciadorFase: faltando referência!");
            return;
        }

        CriarMoedas();
    }

   void CriarMoedas()
{
    var col = plano.GetComponent<Collider>();
    Bounds b = col.bounds;

    float halfX = b.extents.x;
    float halfZ = b.extents.z;

    for (int i = 0; i < quantidadeMoedas; i++)
    {
        float x = Random.Range(-halfX + margemBorda, halfX - margemBorda);
        float z = Random.Range(-halfZ + margemBorda, halfZ - margemBorda);

        Vector3 pos = new Vector3(b.center.x + x, plano.position.y + alturaMoeda, b.center.z + z);
        Quaternion rot = Quaternion.Euler(90, 90, 0);

        GameObject novaMoeda = Instantiate(moedaPrefab, pos, rot);

        novaMoeda.transform.parent = plano;  
    }
}

}
