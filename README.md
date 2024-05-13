# Coleta de métricas com .NET
## Tecnologias
- .NET;
- IDE JetBrains Rider;
## Conceitos aprendidos
- Importancia das métricas
- Métricas personalizadas
- Instrumentação de métricas
- Injeção de dependencias
## 1. Passo a passo: Criar métrica personalizada
Pré-requisitos: 
  - IDE para desenvolvimento em .NET
  - SDK do .NET Core 6 ou uma versão posterior
Contexto: projeto de venda de chapéus.
### 1. Criar console app
- Criar console app através da IDE utilizada
- Fazer referência ao pacote NuGet System.Diagnostics.DiagnosticSource no Project

![console-app](assets/img1.png)
### 2. Definir coleta de medida
- Definir coleta da quantidade de chapéus vendidos, através da utilização do "CreateCounter" para criar um instrumento do Contador.

-> Essa medida pode ser usada na definição de várias métricas, como o número total de chapéus vendidos ou chapéus vendidos/segundo.

![console-app](assets/img2.png)
### 3. Exibir a nova métrica
- Instalar a a ferramenta "dotnet-counters"
![console-app](assets/img3.png)
- Rodar o app:
-     > dotnet run
- Utilizar contadores de dotnet para monitorar o novo contador:
-     > dotnet-counters monitor -n CustomMetric --counters HatCo.Store
-> É esperado que sejam adicionados 4 chapéus por segundo no contador, e ele vai incrementando automaticamente. Ou seja, é simulado que estivessem sendo vendidos 4 chapeus por segundo.
![console-app](assets/img4.png)
![console-app](assets/img5.png)

## 2. Obter um Medidor por meio da injeção de dependência
1. Criar Web App
![console-app](assets/img6.png)
![console-app](assets/img7.png)
2. Definir um tipo para armazenar os instrumentos e registrar o tipo com o contêiner de DI
![console-app](assets/img8.png)
3. Criar classe HatCoMetrics pra fazer a coleta da metrica (com o Counter, igual no exemplo 1) de quantidade de chapeus vendidos.
![console-app](assets/img9.png)
4. Rodar a aplicação e acessar no navegador
![console-app](assets/img10.png)
![console-app](assets/img11.png)
5. Fazer todo o setut do dotnet-counters (igual no exemplo 1)
![console-app](assets/img12.png)
7. Testar adicionar 1 chapeu ao contador pelo swagger
![console-app](assets/img13.png)

-> chapeu adicionado ao contador com sucesso:

![console-app](assets/img14.png)
