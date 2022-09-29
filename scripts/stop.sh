#!/bin/bash

docker compose -f SistemaDeEnvios/docker-compose.yaml down -v
docker compose -f inventory/docker-compose.yaml down -v