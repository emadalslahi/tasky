# 🗂️ Tasky - Task Management System

**Tasky** is a modern task management application built with **.NET 9** using a **Modular Monolithic Architecture**. It helps teams and individuals organize their work, track progress, and improve productivity through powerful task organization features.

---

## 📌 Project Description

Tasky allows users to:
- Create and manage tasks and sub-tasks.
- Assign tasks to team members.
- Set deadlines and priorities.
- Add comments and file attachments to tasks.
- Receive notifications and reminders.
- Group tasks under projects.
- View dashboards and progress reports.

---

## ✅ Functional Requirements

- User registration and authentication.
- Create, update, and delete tasks.
- Assign users to tasks.
- Manage task status: New, In Progress, Completed, etc.
- Add comments to tasks.
- Attach files to tasks.
- Create and manage projects.
- In-app and email notifications.
- Dashboard with analytics.

---

## ⚙️ Non-Functional Requirements

- **Performance**: Responses < 1s on average.
- **Security**: JWT/Identity-based authentication.
- **Scalability**: Modular structure to allow future module addition.
- **Reliability**: Regular database backups.
- **Usability**: Intuitive Razor MVC UI.
- **Extensibility**: API support planned (REST or GraphQL).

---

## 🧱 System Architecture

- **Architecture Style**: Modular Monolithic
- **Backend**: ASP.NET Core 9
- **UI**: Razor Pages / MVC
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Authentication**: ASP.NET Identity or JWT
- **Other Tools**: AutoMapper, FluentValidation, MediatR (optional)

### 🔌 Key Modules

| Module             | Responsibility                      |
|--------------------|--------------------------------------|
| Task Management    | Tasks, sub-tasks, comments           |
| Project Management | Organizing tasks under projects      |
| User Management    | User accounts and roles              |
| Notification       | Email and in-app alerts              |
| Dashboard          | Analytics and task summaries         |
| File Attachments   | Uploading/downloading attachments    |

---

## 🗃️ Core Entities (Aggregates)

- Task
- Project
- User
- Comment
- Notification
- FileAttachment

---

## 🧩 Database Tables

- `Tasks`
- `Projects`
- `Users`
- `TaskAssignments`
- `TaskComments`
- `TaskAttachments`
- `Notifications`

---

## 🔜 Next Steps

- [ ] Generate ER Diagram
- [ ] Implement authentication and modular structure
- [ ] Design UI wireframes
- [ ] Build core task/project logic

---

## 🛠️ Tech Stack

- .NET 9
- EF Core
- Razor MVC
- SQL Server
- AutoMapper
- FluentValidation
- Identity / JWT

---

## 📄 License

This project is licensed under the MIT License.
