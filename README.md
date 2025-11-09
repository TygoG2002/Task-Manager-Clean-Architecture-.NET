# Clean Architecture Task Manager

A minimal **ASP.NET Core MVC** application built with **Clean Architecture** to demonstrate clean layering, separation of concerns, and scalable solution design.

---

## Overview

**Goal:** Learn and apply Clean Architecture principles in a real .NET project.  
**Focus:** Simple CRUD operations (Create, Read, Update, Delete) with clean boundaries between layers.

### Architecture
```
Domain → Application → Infrastructure → Web
```

| Layer | Responsibility |
|-------|----------------|
| **Domain** | Business entities (`TaskItem`) |
| **Application** | Use cases (`CreateTaskHandler`, `UpdateTaskHandler`) |
| **Infrastructure** | EF Core repositories (`TaskRepository`) |
| **Web** | MVC controllers + Razor views (`TaskController`) |

---

## Features

- Create new tasks  
- Mark tasks as complete/incomplete (auto-submit checkbox)  
- Layered architecture with clear boundaries  
- Async EF Core operations  
- Dependency Injection between layers  

---

## Stack

- **.NET 9 / ASP.NET Core MVC**
- **Entity Framework Core (SQL Server)**
- **C# / Razor Views**
- **Clean Architecture pattern**

---

## Architecture Flow

```
View (Razor)
 → Controller (Web)
   → Handler (Application)
     → Repository (Infrastructure)
       → Entity (Domain)
```

---

## What I Learned

- Structuring .NET projects with **Clean Architecture**
- Implementing **Dependency Injection** and **Repositories**
- Connecting UI → Logic → Database in separate layers

---

## Author

**Tygo Geervliet**  

📬 [LinkedIn](https://www.linkedin.com/in/tygo-geervliet)  
💻 [GitHub](https://github.com/tygogeervliet)

---

🪶 *Built as part of my Clean Architecture learning path and portfolio.*
