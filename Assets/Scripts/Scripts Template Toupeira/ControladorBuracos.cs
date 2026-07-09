using System.Collections.Generic;
using UnityEngine;

public class ControladorBuracos : MonoBehaviour
{
    // Lista de Referencias de objetos com o scripts BuracoToupeira
    public List<BuracoToupeira> BuracosToupeira;

    // Variável publica para definir tempo entre Toupeiras
    public float DelayEntreToupeiras = 0.67f;

    // Variável publica para definir tempo que Toupeira fica amostra
    public float TempoDePermanenciaToupeira = 1f;


    // Variável privada para definir se já tem uma toupeira amostra
    bool toupeiraAmostra = false;
    // Variável privada para definir qual toupeira da lista será selecionada
    int toupeiraSelecionada = 0;



    // É chamado 1 vez por frame
    void Update()
    {
        // Checa se a booleana toupeiraAmostra está falsa
        if (toupeiraAmostra == false)
        {
            // Muda a booleana toupeiraAmostra para false
            toupeiraAmostra = true;

            // Invoca a função MostrarToupeiraAleatoria() com o delay DelayEntreToupeiras
            Invoke("MostrarToupeiraAleatoria", DelayEntreToupeiras);
        }
    }


    // Função publica para Mostrar uma toupeira aleatória da lista de toupeiras
    public void MostrarToupeiraAleatoria()
    {
        // Sorteia o valor da variável toupeiraSelecionada como um número entre 0 e 9
        toupeiraSelecionada = Random.Range(0, 9);

        // Chama a função de MostrarToupeira do buraco de toupeira sorteado
        BuracosToupeira[toupeiraSelecionada].MostrarToupeira();

        // Invoca a função EsconderToupeiraAtual() com o delay TempoDePermanenciaToupeira
        Invoke("EsconderToupeiraAtual", TempoDePermanenciaToupeira);
    }

    // Função publica para Esconder a toupeira atualmente fora do buraco
    public void EsconderToupeiraAtual()
    {
        // Chama a função de EsconderToupeira do último buraco de toupeira sorteado
        BuracosToupeira[toupeiraSelecionada].EsconderToupeira();

        // Muda a booleana toupeiraAmostra para true
        toupeiraAmostra = false;
    }
}
