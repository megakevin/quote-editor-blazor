# README

## Create database with:

```sh
docker run -d \
    --name quote-editor-blazor-db \
    -p 5432:5432 \
    --network host \
    -e POSTGRES_DB=quote_editor \
    -e POSTGRES_USER=quote_editor \
    -e POSTGRES_PASSWORD=password \
    postgres:14
```

## Connect to the database with:

```sh
psql -h localhost -U quote_editor -W
```
pw: password
