using System;
using Solution.Interfaces;
using Solution.Classes;

namespace Solution.Factories
{
    class MailingAddressFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Почтовый адрес";
            }
        }

        /// <summary>
        /// Creates class MailingAddress
        /// </summary>
        /// <param name="values">CompanyName, City, Street, HomeAddress, PostalCode</param>
        /// <returns></returns>
        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0 || !(values is string[])) return new MailingAddress();
            var result = (string[])values;
            switch(values.Length){
                case 1:
                    return new MailingAddress(result[0]);
                case 2:
                    return new MailingAddress(result[0], result[1]);
                case 3:
                    return new MailingAddress(result[0], result[1], result[2]);
                case 4:
                    return new MailingAddress(result[0], result[1], result[2], result[3]);
                default:
                    return new MailingAddress(result[0], result[1], result[2], result[3], result[4]);
            }

        }
    }
}
