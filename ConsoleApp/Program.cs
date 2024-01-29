// See https://aka.ms/new-console-template for more information

BayenSolutions.Data.DAO.MySQL.PersonDAOImpl personImpl = new BayenSolutions.Data.DAO.MySQL.PersonDAOImpl();

// personImpl.DeletePerson(person);
// Console.WriteLine(personImpl.AddPerson(person));
// bool success=personImpl.UpdatePerson(person);

/*
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
*/ 

BayenSolutions.Data.DTO.Person person=new BayenSolutions.Data.DTO.Person();
person.Id = 3131;
person.Name = "Vanja";
person.Surname = "Radnicka Munja";
person.Telephone = "012345678";

person.Place = new BayenSolutions.Data.DTO.Place();
person.Place.Name = "Banja Lukaaa";
person.Place.ZipCode = "78000";

BayenSolutions.Data.DTO.Employee employee = new BayenSolutions.Data.DTO.Employee();
employee.Salary = 1810.00;
employee.Nickname = "a";
employee.PasswordHash = "a";
employee.EmployeeRole = new BayenSolutions.Data.DTO.EmployeeRole();
employee.EmployeeRole.Id = 3;
employee.EmployeeRole.Role = "Direktor";
employee.UniqueIdentificationNumber = "0212999105123";

employee.Id = 31;
employee.Name = "Vanja";
employee.Surname = "Djenadija";
employee.Telephone = "065/625-488";
employee.Place = new BayenSolutions.Data.DTO.Place();
employee.Place.Name = "BL";
employee.Place.ZipCode = "78000";

//personImpl.AddPerson(person);
//personImpl.UpdatePerson(person);
//personImpl.AddEmployee(employee);
//personImpl.DeleteEmployee(employee);
//personImpl.DeleteEmployee();
//personImpl.UpdateEmployee(employee);