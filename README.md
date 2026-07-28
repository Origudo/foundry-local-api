# Microsoft AI Foundry Local Web API

A lightweight ASP.NET Core Web API that demonstrates how to integrate **Microsoft AI Foundry Local** and expose local AI models through RESTful endpoints.

This project serves as a starting point for building applications that leverage locally hosted AI models while providing a simple HTTP API for client applications.

## Features

- ASP.NET Core Web API
- Microsoft AI Foundry Local integration
- REST API endpoints
- Dependency Injection
- Configurable through `appsettings.json`
- Designed for future extensibility

## Getting Started

### Prerequisites

- .NET 9 (or later)
- Microsoft AI Foundry Local
- A supported local model installed through Microsoft AI Foundry

### Clone the Repository

```bash
git clone https://github.com/yourusername/your-repository.git
cd your-repository
```

### Configure

Update `appsettings.json` with your Foundry settings.

```json
{
  "FoundryService": {
    "AppName": "MyFoundryApp",
    "ChatCompletionModelName": "your-model-name"
  }
}
```

### Run

```bash
dotnet restore
dotnet run
```

The API will be available at:

```
https://localhost:5001
```

or

```
http://localhost:5000
```

(depending on your launch profile)

## API

Once the application is running, you can access the available endpoints using:

- Swagger UI
- Postman
- curl
- Any HTTP client

Example:

```http
POST /api/...
```

Refer to the Swagger documentation for the available endpoints.

## Why Microsoft AI Foundry Local?

Microsoft AI Foundry Local enables developers to run AI models directly on their local machine without requiring cloud-hosted inference. This allows applications to benefit from:

- Offline AI capabilities
- Lower latency
- Improved privacy
- Reduced cloud inference costs
- Local development and testing

## Roadmap

Future enhancements may include:

- Chat Completion
- Streaming Responses
- Embedding Models
- Retrieval-Augmented Generation (RAG)
- Conversation Memory
- Multiple Model Support
- OpenAI-Compatible Endpoints
- Authentication & Authorization
- Docker Support
- Health Checks
- Logging & Monitoring

## Contributing

Contributions, issues, and feature requests are welcome.

Feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
