package main

import (
	"context"
	"fmt"
	"time"

	"github.com/Azure/azure-service-bus-go"
)

func main() {

ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
defer cancel()

connStr := "Endpoint=sb://cegalteam2.servicebus.windows.net/;SharedAccessKeyName=testpolicy;SharedAccessKey=1AvuobreyE+hiletcL8Tt+rW8qnfVfPFwSEjKko8RDI=;EntityPath=testq1"
if connStr == "" {
	fmt.Println("FATAL: expected environment variable SERVICEBUS_CONNECTION_STRING not set")
	return
}

// Create a client to communicate with a Service Bus Namespace.
ns, err := servicebus.NewNamespace(servicebus.NamespaceWithConnectionString(connStr))
if err != nil {
	fmt.Println(err)
	return
}

// Create a client to communicate with the queue. (The queue must have already been created, see `QueueManager`)
q, err := ns.NewQueue("testq1")
if err != nil {
	fmt.Println("FATAL: ", err)
	return
}

err = q.Send(ctx, servicebus.NewMessageFromString("Hello, World!!!"))
if err != nil {
	fmt.Println("FATAL: ", err)
	return
}

err = q.ReceiveOne(
	ctx,
	servicebus.HandlerFunc(func(ctx context.Context, message *servicebus.Message) error {
		fmt.Println(string(message.Data))
		return message.Complete(ctx)
	}))
if err != nil {
	fmt.Println("FATAL: ", err)
	return
}

}