# 🎮 Coleta 3D

Jogo desenvolvido para a disciplina de **Computação Gráfica**, utilizando a engine **Unity**.  
O objetivo é inclinar o plano para fazer a esfera rolar e **coletar todas as moedas antes do tempo acabar**.

---

## 👥 Integrantes
- **Agatha Santos**
- **Matheus Marini**

---

## 🕹️ Como o jogo funciona

O jogador controla o **ângulo do plano** usando as teclas WASD ou as setas do teclado.  
A esfera rola de acordo com a inclinação, seguindo a física realista da Unity.

O jogo possui:

- Sistema de **moedas aleatórias** criadas na superfície do plano  
- **Timer regressivo** (vence se pegar tudo antes do tempo)  
- Mensagem de **vitória** ou **derrota**  
- Opção de **reiniciar** rapidamente pressionando a tecla **R**  
- HUD 3D mostrando tempo 

---

## 🎯 Objetivo

Coletar todas as moedas antes que o tempo chegue a zero.

---

## ⌨️ Controles

| Tecla | Ação |
|------|-------|
| **W** ou **Seta ↑** | Inclinar o plano para frente |
| **S** ou **Seta ↓** | Inclinar o plano para trás |
| **A** ou **Seta ←** | Inclinar o plano para a esquerda |
| **D** ou **Seta →** | Inclinar o plano para a direita |
| **R** | Reinicia o jogo após vitória/derrota |

---

## 🛠️ Tecnologias e recursos usados

- **Unity 3D**
- **Rigidbody + Física realista**
- **TextMeshPro 3D** para HUD
- **C# Scripts**
  - `MoverPlano.cs` – controla a inclinação do plano
  - `JogadorMoedas.cs` – detecta coleta de moedas
  - `GameController.cs` – timer, HUD, vitória/derrota
  - `GerenciadorFase.cs` – geração de moedas na posição correta
  - `MoedaRotacao.cs` – animação da rotação da moeda
  - `CriarParedesDoPlano.cs` – paredes invisíveis de contenção



