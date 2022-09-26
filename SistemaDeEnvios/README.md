# Sistema de envios

## Requisitos para rodar
 - Docker 20.10.18 instalado

## Como rodar
 - Na pasta raiz, rodar o seguinte comando:
    - `docker compose build ; docker compose up`
 - Em builds posteriores é possível executar o seguinte comando:
    - `docker compose build sistema-de-envios ; docker compose up`
 - Após os containers subirem, abra seu navegador e acesse `http://localhost:5000/swagger`, nesta página você conseguirá testar todos os endpoints desta API.