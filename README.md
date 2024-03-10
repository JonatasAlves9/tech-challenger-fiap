# Tech Challenge FIAP

# Guia de Execução do Kubernetes

Este é um guia passo a passo para executar o Kubernetes e configurar todos os componentes necessários para o seu sistema.

## Clonando o Repositório

1. Clone este repositório em sua máquina local:

    ```
    git clone <URL_DO_SEU_REPOSITORIO>
    ```

## Configurando a Infraestrutura

1. Navegue até o diretório `infra`:

    ```
    cd infra
    ```

2. Aplique as configurações do banco de dados:

    ```
    kubectl apply -f database
    ```

3. Obtenha o Cluster IP do banco de dados executando o seguinte comando:

    ```
    kubectl get svc
    ```

4. Edite o arquivo de ConfigMap localizado em `api/tech-challenger-configmap.yaml` e altere o valor de `DB_HOST` para o Cluster IP obtido.

5. Aplique as configurações do ConfigMap:

    ```
    kubectl apply -f api/tech-challenger-configmap.yaml
    ```

6. Aplique as configurações do Deployment da API:

    ```
    kubectl apply -f api/tech-challenger-deployment.yaml
    ```

Agora a API e o banco de dados estão em execução.

## Configurando o Grafana e o Prometheus

1. Navegue até o diretório `infra/monitoring`:

    ```
    cd ../monitoring
    ```

2. Crie um novo namespace para o monitoramento:

    ```
    kubectl create namespace monitoring
    ```

3. Aplique as configurações do Prometheus:

    ```
    kubectl create -f k8s-prometheus/clusterRole.yaml
    kubectl create -f k8s-prometheus/config-map.yaml
    kubectl create -f k8s-prometheus/prometheus-deployment.yaml
    kubectl create -f k8s-prometheus/prometheus-service.yaml --namespace=monitoring
    ```

4. Aplique as configurações do Grafana:

    ```
    kubectl apply -f kube-state-metrics/
    kubectl create -f k8s-grafana/
    ```

Agora o Grafana e o Prometheus estão em execução.

## Configurando a Escalabilidade

1. Navegue até o diretório `api/scaling`:

    ```
    cd ../../api/scaling
    ```

2. Aplique as configurações de métricas:

    ```
    kubectl apply -f metrics.yaml
    ```

3. Aplique as configurações do Horizontal Pod Autoscaler (HPA):

    ```
    kubectl apply -f hpa.yaml
    ```

Agora todo o sistema está configurado e funcionando perfeitamente.

## Projeto
Sistema de pedidos de uma lanchonete de bairro

## Grupo
  - Marlon - RM 352711
  - Zanaro - RM 352692
  - Jônatas - RM 353060
  - Matheus - RM 352813
  - Luiz - RM 353114

## Desenvolvimento
  - Acompanhamento (Click Up): https://app.clickup.com/9017094286/v/b/8cqbw4e-57
  - Arquitetura (Miro): https://miro.com/app/board/uXjVNQfujpo=/
  - Linguagem: C#
  - Banco de Dados: Postgres
  - Infraestrutura: Containers em Docker
