using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    //Тестовый класс
    public static class AbstractFactory
    {
        public static void Test()
        {
            ShowHero(new ElfCreator());
            ShowHero(new SwordManCreator());
        } 

        public static void ShowHero(Creator creator)
        {
            Body body = creator.CreateBody();
            Weapon weapon = creator.CreateWeapon();

            Console.WriteLine($"Body_Armor: {body.Armor}\nWeapon_Damg {weapon.Damage}");
        }
    }

    //Базовый Creator
    public abstract class Creator
    {
        public abstract Body CreateBody();
        public abstract Weapon CreateWeapon();
    }

    //Конкретные Creator-ы
    public class ElfCreator : Creator
    {
        public override Body CreateBody()
        {
            return new LightArmor(1);
        }

        public override Weapon CreateWeapon()
        {
            return new Bow(1, 1);
        }
    }

    public class SwordManCreator : Creator
    {
        public override Body CreateBody()
        {
            return new HeavyArmor(10);
        }

        public override Weapon CreateWeapon()
        {
            return new Sword(10);
        }
    }

    //Конкретная броня
    public class LightArmor : Body
    {
        private uint armor;

        public override uint Armor => armor;


        public LightArmor(uint armor)
        {
            this.armor = armor;
        }
    }

    public class HeavyArmor : Body
    {
        private uint armor;

        public override uint Armor => armor;


        public HeavyArmor(uint armor)
        {
            this.armor = armor;
        }
    }

    //Конкретное оружие
    public class Bow : Weapon
    {
        private uint damage;

        public override uint Damage => damage;
        public uint Distance { get; private set; }


        public Bow(uint damage, uint distance)
        {
            this.damage = damage;
            Distance = distance;
        }
    }

    public class Sword : Weapon
    {
        private uint damage; 

        public override uint Damage => damage;
        

        public Sword(uint damage)
        {
            this.damage = damage;
        }
    }

    //Базовые продукты
    public abstract class Body
    {
        public abstract uint Armor { get; }
    }

    public abstract class Weapon
    {
        public abstract uint Damage { get; }
    }
}
