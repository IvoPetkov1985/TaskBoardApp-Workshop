namespace TaskBoardApp.Data.DataConstants
{
    public static class DataConstants
    {
        public const int TaskTitleMinLength = 5;
        public const int TaskTitleMaxLength = 70;

        public const string TaskInputErrorMsg = "{0} should be between {2} and {1} characters long.";
        public const string TaskCreationFormat = "dd/MM/yyyy HH:mm";

        public const int TaskDescrMinLength = 10;
        public const int TaskDescrMaxLength = 1000;

        public const int BoardNameMinLength = 3;
        public const int BoardNameMaxLength = 30;

        public const string BoardNotExisting = "Board does not exist!";
    }
}
