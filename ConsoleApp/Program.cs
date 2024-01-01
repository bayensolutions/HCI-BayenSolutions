// See https://aka.ms/new-console-template for more information

BayenSolutions.Data.DAO.MySQL.PersonDAOImpl personImpl = new BayenSolutions.Data.DAO.MySQL.PersonDAOImpl();

// personImpl.DeletePerson(person);
// Console.WriteLine(personImpl.AddPerson(person));
// bool success=personImpl.UpdatePerson(person);

Console.WriteLine("OSOBE");
foreach (var item in personImpl.GetPersons())
{
    Console.WriteLine(item);
}
Console.WriteLine("KLIJENTI");
foreach(var item in personImpl.GetClients())
{
    Console.WriteLine(item);
}

Console.WriteLine("ZAPOSLENI");
foreach (var item in personImpl.GetEmployees())
{
    Console.WriteLine(item);
}

//personImpl.DeleteEmployee();