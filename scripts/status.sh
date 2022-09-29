#!/bin/bash

docker compose -f SistemaDeEnvios/docker-compose.yaml ps
docker compose -f inventory/docker-compose.yaml ps