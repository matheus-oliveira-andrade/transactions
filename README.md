# Transactions

Project to expose, through an API, the report of movements from the accounts. Transactions are created by the `Seed` console application and published to a topic in `RabbitMQ`, then read by the `Movements.AsyncReceiver` application, which processes and saves the data in the `PostgreSQL` database. This data is then exposed through the `Movements.Api` at the `/report/{{accountId}}` endpoint.

# How run 

With docker installed, run

```bash 
docker-compose up -d
```

Movements api docs are exposed in [`localhost:9000/movements/swagger`](localhost:9000/movements/swagger)

Logs of all applications are available in kibana exposed in [`localhost:9001`](localhost:9001), configuring index pattern:
   - Access [`localhost:9001/app/management/kibana/indexPatterns`](localhost:9001/app/management/kibana/indexPatterns)
   - `Create data view`
   - Type `fluentd-logs` in name
   - `Create data view` button
