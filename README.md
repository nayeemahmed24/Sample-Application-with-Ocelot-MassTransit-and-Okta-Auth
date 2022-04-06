# Sample-Application-with-Ocelot-MassTransit-and-Okta-Auth

Here I just implemented a simple system with Ocelot Api gateway and MassTransit where Okta used for authorization.
The system has 3 parts:

1. An Angular Application where used hosted okta auth.
2. Ocelot API Gateway which redirect request to microservices.
3. Two Webservice which recieve request and send them to some worker service via Rabbitmq.
4. Okta is used to authorize the request in Ocelot Api gateway.  

Note: Currently I am using token copying from localstorage to test api gateway and endpoints. 

Credentials:
Username- isaac@gmail.com
Password- 1qazzaq12wsx
