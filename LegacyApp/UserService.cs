using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(surname))
                return false;

            if (!IsValidEmail(email))
                return false;

            var age = CalculateAge(dateOfBirth);
            if (age < 21)
                return false;

            var client = GetClientById(clientId);
            if (client is null)
                return false;

            var user = CreateUser(client, firstName, surname, email, dateOfBirth);

            if (client.ClientType == ClientType.VeryImportantClient)
            {
                user.HasCreditLimit = false;
            }
            else
            {
                user.HasCreditLimit = true;
                user.CreditLimit = GetUserCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);

                if (user.CreditLimit < 500)
                    return false;

                if (client.ClientType == ClientType.ImportantClient)
                    user.CreditLimit *= 2;
            }

            SaveUser(user);

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (!email.Contains("@") || !email.Contains("."))
                return false;

            return true;
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))
                age--;

            return age;
        }

        private static Client GetClientById(int clientId)
        {
            //return ClientRepository.GetById(clientId);
             return new Client
                        {
                            Id = 1,
                            Name = "ImportantClient",
                            ClientStatus = ClientStatus.none
                        };
        }

        private static User CreateUser(Client client, string firstName, string surname, string email, DateTime dateOfBirth)
        {
            return new User
            {
                Client = client,
                Firstname = firstName,
                Surname = surname,
                EmailAddress = email,
                DateOfBirth = dateOfBirth
            };
        }

        private static int GetUserCreditLimit(string firstName, string surname, DateTime dateOfBirth)
        {
            using var userCreditService = new UserCreditServiceClient();
            return userCreditService.GetCreditLimit(firstName, surname, dateOfBirth);
        }

        private static void SaveUser(User user)
        {
            UserDataAccess.AddUser(user);
        }
    }
}