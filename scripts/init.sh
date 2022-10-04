#!/bin/bash

docker compose -f SistemaDeEnvios/docker-compose.yaml up -d --build
docker compose -f inventory/docker-compose.yaml up -d --build
docker compose -f digital-wallet/docker-compose.yaml up -d --build