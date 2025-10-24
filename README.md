# Task Manager - Full Stack Application

A simple task manager application built with .NET 8 Core (Backend) and React + TypeScript (Frontend).

## Features

- ✅ Display a list of tasks
- ✅ Add a new task with description
- ✅ Toggle task completion status
- ✅ Edit task description
- ✅ Delete a task
- ✅ In-memory data storage (no database required)
- ✅ RESTful API with Swagger documentation

## Project Structure

```
Project 1/
├── Backend/
│   └── TaskManagerAPI/          # .NET 8 Web API
│       ├── Controllers/         # API Controllers
│       ├── Models/             # Data Models
│       └── Program.cs          # Application entry point
└── Frontend/
    └── src/                    # React + TypeScript App
        ├── api/                # API integration
        ├── App.tsx            # Main component
        └── main.tsx           # React entry point
```

## Prerequisites

### Backend (.NET 8)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Frontend (React + TypeScript)
- [Node.js](https://nodejs.org/) (v18 or higher)
- npm (comes with Node.js)

## Installation & Setup

### 1. Backend Setup

Navigate to the backend directory:
```powershell
cd "c:\Users\yashr\Project 1\Backend\TaskManagerAPI"
```

Restore dependencies:
```powershell
dotnet restore
```

Run the backend API:
```powershell
dotnet run
```

The API will be available at: `http://localhost:5000`
Swagger documentation: `http://localhost:5000/swagger`

### 2. Frontend Setup

Open a new terminal and navigate to the frontend directory:
```powershell
cd "c:\Users\yashr\Project 1\Frontend"
```

Install dependencies:
```powershell
npm install
```

Run the development server:
```powershell
npm run dev
```

The frontend will be available at: `http://localhost:3000`

## API Endpoints

- `GET /api/tasks` - Get all tasks
- `POST /api/tasks` - Create a new task
- `PUT /api/tasks/{id}` - Update a task
- `DELETE /api/tasks/{id}` - Delete a task

## Usage

1. Start the backend API (runs on port 5000)
2. Start the frontend app (runs on port 3000)
3. Open your browser and navigate to `http://localhost:3000`
4. Start managing your tasks!

## Technologies Used

### Backend
- .NET 8 Core
- ASP.NET Core Web API
- Swagger/OpenAPI
- In-memory storage

### Frontend
- React 18
- TypeScript
- Vite
- Axios (for API calls)
- CSS3

## Time Estimate

Estimated completion time: 3-6 hours

## Enhancements (Future)

- Task filtering (All / Completed / Active)
- Framework integration (Bootstrap or Tailwind)
- LocalStorage persistence
- State management with Redux or Tailwind
- Save tasks in localStorage
- Use Axios or Fetch for API integration
- React Hooks for state management
