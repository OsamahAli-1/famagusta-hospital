namespace famagustaHospital.Entities.Exceptions
{
    public sealed class AuthorizationBadRequestException:BadRequestException
    {
        public AuthorizationBadRequestException(string userId) : base($"User with id {userId} not permitted to access or take this action")
        {

        }
    }
}
