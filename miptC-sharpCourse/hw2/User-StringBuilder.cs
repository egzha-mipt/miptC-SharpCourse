using System;
using System.Text;

namespace hw2
{
    internal class UserClass
    {
        private class User
        {
            public int Id { get; set; }

            private string? _firstName;
            public string FirstName
            {
                get => string.IsNullOrEmpty(_firstName) ? "(У user не указано Имя)" : _firstName;
                set => _firstName = string.IsNullOrWhiteSpace(value) ? null : value;
            }
            private string? _lastName;
            public string LastName
            {
                get => string.IsNullOrWhiteSpace(_lastName) ? "(у User не указана Фамилия)" : _lastName; 
                set => _lastName = string.IsNullOrWhiteSpace(value) ? null : value;
            }
            
            public string GetFullNameAndId()
            {
                StringBuilder finalString = new StringBuilder();
                finalString.Append(FirstName);
                finalString.Append(' ');
                finalString.Append(LastName);
                finalString.Append(" c ID = ");
                finalString.Append(Id);
                
                return finalString.ToString();
            }
        }
        
        public static void UsertringBuilder()
        {
            User user = new User
            {
                Id = 1, FirstName = "Иван", LastName = "Смирнов"
            };
            
            Console.WriteLine(user.GetFullNameAndId());
        }

    }
}