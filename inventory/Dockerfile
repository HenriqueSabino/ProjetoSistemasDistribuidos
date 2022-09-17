FROM python:3.7.11-slim-buster

RUN apt-get update -y && apt-get install -y build-essential libpq-dev

RUN mkdir /code

WORKDIR /code

COPY ./requirements.txt /tmp/requirements.txt
RUN pip install --upgrade pip
RUN pip install --no-cache-dir -r /tmp/requirements.txt

COPY ./inventory /code/inventory
WORKDIR /code/inventory
