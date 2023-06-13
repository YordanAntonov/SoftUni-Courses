﻿namespace TaskBoardApp.Data.Common
{
    public static class EntityConstraints
    {
        //Task Constraints:

        public const int TaskTitleMaxLength = 70;
        public const int TaskTitleMinLength = 5;

        public const int TaskDescriptionMaxLength = 1000;
        public const int TaskDescriptionMinLength = 10;

        //Board Constraints:
        public const int BoardNameMaxLength = 30;
        public const int BoardNameMinLength = 3;

    }
}