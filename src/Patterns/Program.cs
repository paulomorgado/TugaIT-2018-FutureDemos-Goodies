using System;

class Program
{
    static void Main(string[] args)
    {
        var professor = new Professor("Mads", "Torgersen", "Computer Science");

        var people = new[]
        {
            professor,
            new Student("Phillip", "Carter", professor),
            new Person("Dustin", "Campbell")
        };

        foreach (var p in people)
        {
            Console.WriteLine(M(p));
        }
    }

    static string M(Person person)
    {
        return person switch
        {
            Professor p =>
                $"Dr. {p.LastName}, Professor of {p.Subject}",
            Student s =>
                $"{s.FirstName}, Student of Dr. {s.Advisor.LastName}",
            Person { LastName: "Campbell", FirstName: var fn } =>
                $"Please, enroll, {fn}",
            _ =>
                "Come back next year!"
        };
    }
}

class Person
{
    public string FirstName { get; }
    public string LastName { get; }

    public Person(string firstName, string lastName)
        => (FirstName, LastName) = (firstName, lastName);

    public void Deconstruct(out string firstName, out string lastName)
        => (firstName, lastName) = (FirstName, LastName);
}

class Professor : Person
{
    public string Subject { get; }

    public Professor(string firstName, string lastName, string subject)
        : base(firstName, lastName) => Subject = subject;

    public void Deconstruct(out string firstName, out string lastName, out string subject)
        => (firstName, lastName, subject) = (FirstName, LastName, Subject);
}

class Student : Person
{
    public Professor Advisor { get; }

    public Student(string firstName, string lastName, Professor advisor)
        : base(firstName, lastName) => Advisor = advisor;

    public void Deconstruct(out string firstName, out string lastName, out Professor advisor)
        => (firstName, lastName, advisor) = (FirstName, LastName, Advisor);
}
