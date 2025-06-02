# Coworking Space Booking System

## Application Structure

The system consists of 3 main components:
1. **Backend API** (ASP.NET Core)
   - RESTful API for managing workspaces, zones, users and bookings
   - Uses Entity Framework Core for database operations
   - Includes Swagger documentation

2. **Frontend** (Angular)
   - Single-page application for user interactions
   - Implements booking management interface
   - Communicates with backend via HTTP requests

3. **Database** (PostgreSQL)
   - Stores all application data
   - Runs in Docker container

## API Endpoints

### Workspaces
- `GET /api/workspaces` - List all workspaces
- `POST /api/workspaces` - Create new workspace
- `GET /api/workspaces/{id}` - Get workspace details
- `PUT /api/workspaces/{id}` - Update workspace
- `DELETE /api/workspaces/{id}` - Delete workspace

### Bookings
- `GET /api/bookings` - List all bookings
- `POST /api/bookings` - Create new booking
- `GET /api/bookings/{id}` - Get booking details
- `PUT /api/bookings/{id}` - Update booking
- `DELETE /api/bookings/{id}` - Delete booking

## How to Run

### Prerequisites
- Docker
- .NET 6 SDK
- Node.js 16+

### Running with Docker
1. Copy `.env.example` to `.env` and configure variables
2. Run:
```bash
docker-compose up -d
```

# Deployment Options

## GitLab CI/CD
1. Ensure you have `.gitlab-ci.yml` in your project root
2. Push your code to GitLab repository
3. Configure CI/CD variables in GitLab:
   - `DOCKER_REGISTRY_USER`
   - `DOCKER_REGISTRY_PASSWORD`
   - `AZURE_CREDENTIALS`

## Azure Deployment
### Prerequisites
- Azure CLI installed
- Docker Hub or Azure Container Registry credentials

### Steps
1. Login to Azure:
```bash
az login
```
