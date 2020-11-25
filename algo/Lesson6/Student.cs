using System;


namespace Lesson6
{
    
    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public class Student : IComparable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public int CompareTo(object other)
        {
            if (other is Student)
                return this.Age.CompareTo((other as Student).Age);
            throw new ArgumentException("Student is expected");
        }

        public long Hash()
        {
            string input = ToString();
            long result = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                result += input[i] * input[i + 1];
            }
            return result;
        }

        public override string ToString() {
            return $"{{Id: {Id}, Name: {FirstName} {LastName}, Age: {Age}, Gender: {Gender}}}";
        }

    }
}
