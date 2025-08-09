namespace OmdhSoft.Tasky.Modules.Shared.Domain
{
    /// <summary>
    /// Centralized schema and table names for database entities
    /// </summary>
    public static class Schemas
    {
        // ========== Schemas ==========
        public const string Users = "users";
        public const string Teams = "teams";
        public const string Projects = "projects";
        public const string Tasks = "tasks";
        public const string Notifications = "notifications";
        public const string AuditLogs = "auditlogs";

        // ========== Users Module Tables ==========
        public const string UsersTable = "users";

        // ========== Teams Module Tables ==========
        public const string TeamsTable = "teams";

        // ========== Projects Module Tables ==========
        public const string ProjectsTable = "projects";

        // ========== Tasks Module Tables ==========
        public const string TasksTable = "tasks";
        public const string TaskAttachmentsTable = "task_attachments";
        public const string SubTasksTable = "sub_tasks";
        public const string TaskCommentsTable = "task_comments";
        public const string TaskAssigneesTable = "task_assignees";

        // ========== Notifications Module Tables ==========
        public const string NotificationsTable = "notifications";

        // ========== AuditLogs Module Tables ==========
        public const string AuditLogsTable = "audit_logs";
    }
}