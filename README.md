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

# 🗂️ Tasky - نظام إدارة المهام

**Tasky** هو تطبيق حديث لإدارة المهام تم بناؤه باستخدام **.NET 9** بنمط **Monolithic Modular Architecture**. يساعد الفرق والأفراد على تنظيم العمل، تتبع التقدم، وزيادة الإنتاجية من خلال أدوات فعّالة لإدارة وتنظيم المهام.

---

## 📌 وصف المشروع

يتيح Tasky للمستخدمين ما يلي:
- إنشاء المهام وإدارتها، بما في ذلك المهام الفرعية.
- تعيين المهام لأعضاء الفريق.
- تحديد المواعيد النهائية والأولويات.
- إضافة تعليقات ومرفقات لكل مهمة.
- استقبال إشعارات وتنبيهات.
- تنظيم المهام ضمن مشاريع.
- عرض تقارير ولوحات تحكم توضح التقدم.

---

## ✅ المتطلبات الوظيفية

- تسجيل مستخدم جديد وتسجيل الدخول.
- إنشاء، تعديل، حذف المهام.
- تعيين مستخدمين إلى المهام.
- إدارة حالات المهام: جديدة، جارية، مكتملة، إلخ.
- إضافة تعليقات على المهام.
- إرفاق ملفات.
- إنشاء وإدارة المشاريع.
- إرسال إشعارات داخلية وعبر البريد الإلكتروني.
- لوحة تحكم تعرض ملخصات وتقارير.

---

## ⚙️ المتطلبات غير الوظيفية

- **الأداء**: استجابة أقل من 1 ثانية في المتوسط.
- **الأمان**: المصادقة باستخدام JWT أو ASP.NET Identity.
- **القابلية للتوسع**: بنية وحدات قابلة للتوسعة مستقبلاً.
- **الموثوقية**: نسخ احتياطي دوري للبيانات.
- **سهولة الاستخدام**: واجهة بسيطة وسلسة باستخدام Razor MVC.
- **إمكانية التوسعة**: دعم API لاحقًا (REST أو GraphQL).

---

## 🧱 بنية النظام

- **نمط المعمارية**: Modular Monolithic
- **الخلفية**: ASP.NET Core 9
- **واجهة المستخدم**: Razor Pages / MVC
- **ORM**: Entity Framework Core
- **قاعدة البيانات**: SQL Server
- **المصادقة**: ASP.NET Identity أو JWT
- **أدوات مساعدة**: AutoMapper، FluentValidation، MediatR (اختياري)

### 🔌 الوحدات الأساسية

| الوحدة              | الوظيفة                                 |
|---------------------|------------------------------------------|
| إدارة المهام         | المهام، المهام الفرعية، التعليقات         |
| إدارة المشاريع       | تنظيم المهام ضمن مشاريع                  |
| إدارة المستخدمين     | الحسابات والصلاحيات                      |
| الإشعارات            | البريد الإلكتروني والتنبيهات داخل النظام |
| لوحة التحكم          | الإحصائيات والتقارير                     |
| إدارة الملفات        | تحميل وتنزيل المرفقات                    |

---

## 🗃️ الكيانات الأساسية (Aggregates)

- Task (مهمة)
- Project (مشروع)
- User (مستخدم)
- Comment (تعليق)
- Notification (إشعار)
- FileAttachment (مرفق)

---

## 🧩 الجداول الأساسية في قاعدة البيانات

- `Tasks`
- `Projects`
- `Users`
- `TaskAssignments`
- `TaskComments`
- `TaskAttachments`
- `Notifications`

---

## 🔜 الخطوات القادمة

- [ ] إنشاء مخطط ER للبيانات
- [ ] تنفيذ نظام تسجيل الدخول والوحدات
- [ ] تصميم واجهات الاستخدام (Wireframes)
- [ ] بناء منطق المهام والمشاريع

---

## 🛠️ التقنيات المستخدمة

- .NET 9
- EF Core
- Razor MVC
- SQL Server
- AutoMapper
- FluentValidation
- Identity / JWT

---

## 📄 الرخصة

هذا المشروع مرخص تحت رخصة MIT.
