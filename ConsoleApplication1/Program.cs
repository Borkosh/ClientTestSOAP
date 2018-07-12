using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.pplService;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)

        {
            //Create header objects
            var protocolVersion = "4.0";
            var id = Guid.NewGuid().ToString();
            var userId = "EE37007160274";
            var service = new XRoadServiceIdentifierType
            {
                xRoadInstance = "ee-dev",
                memberClass = "COM",
                memberCode = "11333578",
                subsystemCode = "aktorstest-db01",
                serviceCode = "personList",
                serviceVersion = "v1",
                objectType = XRoadObjectType.SERVICE
            };
            var client = new XRoadClientIdentifierType
            {
                xRoadInstance = "ee-dev",
                memberClass = "COM",
                memberCode = "11333578",
                subsystemCode = "misp2-01",
                objectType = XRoadObjectType.SUBSYSTEM
            };


            var PLrequest = new personListRequest(
                                client,
                               service,
                               userId,
                                id,
                               protocolVersion,                               
                                 "",
                                 "Torgoev");


            person_registerClient clientPerson = new person_registerClient();

            // Используйте переменную "client", чтобы вызвать операции из службы.
            // Всегда закройте клиент.


            var response = clientPerson.personList(PLrequest);

            //Console.WriteLine(response.ToString());

           // var response = clientPerson;
            if ((response.id != null)) { 
                Console.WriteLine("Имя : "+response.person.firstName);
                Console.WriteLine("Фамилия : " + response.person.lastName);

                Console.WriteLine("Дата рождения : " + response.person.birthDate);

                Console.WriteLine("Адрес : " + response.person.personContact.address);
                Console.WriteLine("Email : " );
                foreach (String value in response.person.personContact.email){
                    Console.WriteLine("    " + value);                
                }
            

                Console.WriteLine("Phone : ");
                foreach (String value in response.person.personContact.phone)
                {
                    Console.WriteLine("    " + value);
                }
            }
            else
            {
                Console.WriteLine("Не найден!");
            }

            
            String nn = Console.ReadLine();
            clientPerson.Close();
        }
    }
}
