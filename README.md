# Task Manager

A full-stack task manager application built with .NET 8 Core and React + TypeScript.

 **Live Demo:** https://harsha-050.github.io/Task-manager-app/

## Features

- Add, edit, and delete tasks
- Toggle task completion status
- RESTful API with Swagger documentation
- In-memory data storage

## Technologies

**Backend**
- .NET 8 Core Web API
- Swagger/OpenAPI

**Frontend**
- React 18 + TypeScript
- Vite
- Axios

## Deployment

- **Frontend:** GitHub Pages
- **Backend:** Render

## Local Setup

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18 or higher)

### Clone Repository
```bash
git clone https://github.com/harsha-050/Task-manager-app.git
cd Task-manager-app
```

### Backend Setup
```bash
cd Backend/TaskManagerAPI
dotnet restore
dotnet run
```
Backend runs at: `http://localhost:5000`

### Frontend Setup
Open a new terminal:
```bash
cd Frontend
npm install
npm run dev
```
Frontend runs at: `http://localhost:5173`
