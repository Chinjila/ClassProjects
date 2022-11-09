using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    public class Parent
    {
        public Parent()
        {
            x = 100;
            y = 200;
        }
        protected int x;
        private int y;
        void Test()
        {
            this.x = 1;
            this.y = 1;
        }
        protected internal int GetY() =>this.y;
        protected void ProtectedMethod() { y++; }
        protected internal virtual void VirtualMethod() { Console.WriteLine("Parent Virtual Method");  }
        protected internal void NonVirtualMethod() { Console.WriteLine("Parent NonVirtual Method"); }
    }

    public sealed class Child : Parent
    {   internal new void NonVirtualMethod() { Console.WriteLine("Child NonVirtual Method"); }
        //protected internal override void VirtualMethod()
        //{
        //    Console.WriteLine("Child Virtual Method");
        //}
        
        public Child() : base()
        {
            x = 150;
        }
        void Test() {
            this.x = 5;
            this.GetY();
            this.Test2();
            base.ProtectedMethod();
        }
        void Test2()
        {
            this.x = 5;
            this.GetY();
            ProtectedMethod();
        }

    }

    internal class NotRelated
    {
        void Test()
        {
            Parent p = new();
            p.GetY();
        }
    }
}
