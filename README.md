# Purchase Notification Service

This project is a purchase notification service that uses **RabbitMQ** for asynchronous communication between systems. The system includes a **producer** that sends purchase information to a RabbitMQ queue, and a **consumer** that receives and processes the information.

## Technologies Used

- **ASP.NET Core**: Used for backend development.
- **RabbitMQ**: Used for messaging and asynchronous communication.
- **C#**: The primary language used in the project.
- **JSON**: Data format for communication between the producer and consumer.

## Features

- Send purchase data (product name and price) via RabbitMQ.
- Consume and process data from the RabbitMQ queue.
- Display received purchase information in the consumer console.

## Prerequisites

Before you begin, you will need to have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [RabbitMQ](https://www.rabbitmq.com/download.html)
- [Git](https://git-scm.com/)

## Installation and Setup

1. Clone this repository:
    ```bash
    git clone https://github.com/KevinLucasG/PurchaseNotify.git
    ```

2. Install the necessary dependencies:
    ```bash
    cd PurchaseNotify
    ```

3. Configure and start **RabbitMQ** locally:
   - Install RabbitMQ on your machine if you haven't already.
   - Run RabbitMQ locally using the command:
     ```bash
     rabbitmq-server
     ```

4. Configure RabbitMQ connection variables in the code:
   - The host and queue name configuration can be found in the `RabbitMqService` class:

   ```csharp
   public RabbitMqService(string hostName = "localhost", string queueName = "Purchase")
