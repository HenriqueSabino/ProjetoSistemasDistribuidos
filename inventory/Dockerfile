FROM python:3.9.14-slim-buster

ENV PYTHONUNBUFFERED 1

RUN apt-get update && apt-get install -y build-essential libpq-dev

RUN mkdir -p /code
EXPOSE 8000
WORKDIR /code

COPY ./requirements/ /code/requirements/
RUN pip install --upgrade pip
RUN pip install --no-cache-dir -r /code/requirements/dev.txt

COPY ./app /code/app

WORKDIR /code/app
