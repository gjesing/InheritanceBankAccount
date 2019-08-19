using System;

namespace InheritanceBankAccount.ClassLib
{
    public abstract class Entity
    {
        int id;

        public Entity()
        {

        }
        public Entity(int id)
        {
            Id = id;
        }

        public int Id { get => id; set => id = value; }
    }
}
