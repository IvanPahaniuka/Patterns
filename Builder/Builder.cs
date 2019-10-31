using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    //Тестовый класс
    public static class BuilderTest
    {
        public static void Test()
        {
            Builder builder = new AndreiBuilder();
            Director director = new Director();

            Person person = director.Construct(builder);
            Console.WriteLine($"Person: {person.ToString()}");
        }
    }

    //Распорядитель
    public class Director
    {

        public Person Construct(Builder builder)
        {
            builder.SetAge();
            builder.SetName();
            builder.SetGender();
            return builder.Build();
        }
    }

    //Базовый builder
    public abstract class Builder
    {
        public abstract void SetName();
        public abstract void SetAge();
        public abstract void SetGender();

        public abstract Person Build();
    }

    //Класс личности
    public class Person
    {
        public string Name { get; internal set; }
        public string Gender { get; internal set; }
        public uint Age { get; internal set; }

        public override string ToString()
        {
            return $"Age: {Age}; Name: {Name}; Gender: {Gender}";
        }
    }

    //Класс личности Андрея
    public class AndreiBuilder : Builder
    {
        private Person person = new Person();

        public override void SetAge()
        {
            person.Age = 19;
        }

        public override void SetGender()
        {
            person.Gender = "Machine";
        }

        public override void SetName()
        {
            person.Name = "Andrei";
        }

        public override Person Build()
        {
            return person;
        }
    }


}
