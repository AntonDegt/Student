using System;

namespace ConsoleСSApp
{
    class Aspirant : Student
    {
        private string topic;

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public Aspirant (string Name, string Surname, DateTime DateOfBirth, string Address, string PhoneNumber, string Topic)
            : base(Name, Surname, DateOfBirth, Address, PhoneNumber)
        {
            this.Topic = Topic;
        }

        public override string ToString()
        {
            return base.ToString() + " " + Topic;
        }
        public object Clone()
        {
            Aspirant clone = new Aspirant(Name, Surname, DateOfBirth, Address, PhoneNumber, Topic);



            return clone;
        }
    }
}
