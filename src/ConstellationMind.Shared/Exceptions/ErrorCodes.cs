namespace ConstellationMind.Shared.Exceptions
{
    public class ErrorCodes
    {
        public static string EmailInUse => "Email_in_use";
        public static string InvalidCredentials => "Invalid_credentials";
        public static string InvalidCurrentPassword => "Invalid_current_password";
        public static string InvalidEmail => "Invalid_email";
        public static string InvalidPassword => "Invalid_password";
        public static string InvalidRole => "Invalid_role";
        public static string InvalidFirstName => "Invalid_first_name";
        public static string InvalidNickname => "Invalid_nickname";
        public static string InvalidPoints => "Invalid_points";
        public static string InvalidRefreshToken => "Invalid_refresh_token";
        public static string PlayerNotFound => "Player_not_found";
        public static string StarNotFound => "Star_not_found";
        public static string PlayerIdIsNullOrEmpty => "Player_ID_is_null_or_empty";
        public static string ConstellationNotFound => "Constellation_not_found";
        public static string StarAlreadyExist => "Star_already_exist";
        public static string ConstellationAlreadyExist => "Constellation_already_exist";
        public static string CoordinatesAlreadyExist => "Coordinates_already_exist";
        public static string PlayerAlreadyExist => "Player_already_exist";
        public static string NullOrEmptyCollection => "Null_or_empty_collection";
        public static string InvalidatedRefreshToken => "Invalidated_refresh_token";
    }
}
