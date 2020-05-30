using System;

namespace eHospital
{
    public abstract class Antishiz
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }

    public class Drug : Antishiz
    {
        private string info;
        protected int id;
        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }



    }

    public class Procedure : Antishiz
    {
        private string info;
        protected int id;
        public string Info
        {
            get { return info; }
            set { info = value; }

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        //todo: only doctor can set procedure and drugs(in treatment class)
    }
}


