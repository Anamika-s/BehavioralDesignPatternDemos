using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviouralPatternDemos
{
    public abstract class Colleague
    {
        protected IMediator _mediator;

        public Colleague(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(IMediator mediator) : base(mediator) { }

        public void Send(string msg)
        {
            Console.WriteLine("A send message:" + msg);
            _mediator.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("A receive message:" + msg);
        }
    }

    public class ConcreteColleagueB : Colleague
    {
        public ConcreteColleagueB(IMediator mediator) : base(mediator) { }

        public void Send(string msg)
        {
            Console.WriteLine("B send message:" + msg);
            _mediator.SendMessage(this, msg);
        }

        public void Receive(string msg)
        {
            Console.WriteLine("B receive message:" + msg);
        }
    }

    public interface IMediator
    {
        void SendMessage(Colleague caller, string msg);
    }

    public class ConcreteMediator : IMediator
    {
        public ConcreteColleagueA Colleague1 { get; set; }

        public ConcreteColleagueB Colleague2 { get; set; }

        public void SendMessage(Colleague caller, string msg)
        {
            if (caller == Colleague1)
                Colleague2.Receive(msg);
            else
                Colleague1.Receive(msg);
        }
    }
    class MediatorDemo1
    {
        public static void Main()
        {
            IMediator mediator = new ConcreteMediator();
            Colleague colleague1 = new ConcreteColleagueA(mediator);
            Colleague colleague2 = new ConcreteColleagueB(mediator);

            ConcreteColleagueA concreteColleagueA = new ConcreteColleagueA(mediator);
            ConcreteColleagueB concreteColleagueB = new ConcreteColleagueB(mediator);

            ConcreteMediator mediator1 = new ConcreteMediator();
            mediator1.Colleague1 = concreteColleagueA;
            mediator1.Colleague2 = concreteColleagueB;
            // mediator.SendMessage(concreteColleagueA, "Hi from A");
            concreteColleagueA.Send("This id from Col A");
            concreteColleagueA.Receive("This is recd");



        }
    }
}
