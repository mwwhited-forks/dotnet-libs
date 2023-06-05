namespace Nucleus.Core.Contracts
{
    // TODO: Core module should not contain external module business logic.  Need to refactor how this works
    public static class Rights
    {
        public static class UserManagement
        {
            public const string Manager = "right_users_write";
        }
        public static class Lesson
        {
            public const string Manager = "right_lesson_admin";
        }
        public static class Blog
        {
            public const string Manager = "right_blog_admin";
        }
        public static class Project
        {
            public const string Manager = "right_project_admin";
        }
    }
}
