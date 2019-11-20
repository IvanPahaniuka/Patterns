using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    //Тестовый класс
    public static class CommandTest
    {
        public static void Test()
        {
            Tower tower1 = new Tower("BossTower");
            ICommand command1 = new FireTowerCommand(tower1);
            MultiCommand manager1 = new MultiCommand(command1);

            manager1.Execute();

            
            Tower tower2 = new Tower("HeroTower");
            ICommand command2 = new HealTowerCommand(tower2);
            ICommand command3 = new FireTowerCommand(tower2);
            MultiCommand manager2 = new MultiCommand(command2, command3);

            manager2.Execute();


            WriteTowerState(tower1);
            WriteTowerState(tower2);

            manager2.Undo();
            Console.WriteLine("A hero tower has been destroyed!");
            WriteTowerState(tower2);

            manager1.Undo();
            Console.WriteLine("A boss tower has been destroyed!");
            WriteTowerState(tower1);

        }

        private static void WriteTowerState(Tower tower)
        {
            if (tower == null)
                return;

            Console.WriteLine($"Tower: {tower.Name}; Fire: {tower.IsFire}; Heal: {tower.IsHeal}");
        }
    }

    //Базовый класс комманды
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    //Класс башня
    public class Tower
    {
        public bool IsHeal { get; internal set; } = false;
        public bool IsFire { get; internal set; } = false;
        public string Name { get; set; } 

        public Tower(string name)
        {
            Name = name;
        }

    }

    //Конкретные комманды для башни
    public class HealTowerCommand : ICommand
    {
        public Tower Tower { get; private set; }

        public HealTowerCommand(Tower tower)
        {
            SetTower(tower);
        }

        public void SetTower(Tower tower)
        {
            Tower = tower ?? throw new Exception();
        }

        public void Execute()
        {
            Tower.IsHeal = true;
        }

        public void Undo()
        {
            Tower.IsHeal = false;
        }
    }

    public class FireTowerCommand : ICommand
    {
        public Tower Tower { get; private set; }

        public FireTowerCommand(Tower tower)
        {
            SetTower(tower);
        }

        public void SetTower(Tower tower)
        {
            Tower = tower ?? throw new Exception();
        }

        public void Execute()
        {
            Tower.IsFire = true;
        }

        public void Undo()
        {
            Tower.IsFire = false;
        }
    }

    //Пустая комманда
    public class EmptyCommand : ICommand
    {
        public void Execute()
        {
            
        }

        public void Undo()
        {
            
        }
    }

    //Комманда-список других комманд
    public class MultiCommand: ICommand
    {
        private List<ICommand> commands = new List<ICommand>();

        public MultiCommand(params ICommand[] commands)
        {
            this.commands.AddRange(commands);
        }

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void RemoveCommand(ICommand command)
        {
            commands.Remove(command);
        }

        public void Execute()
        {
            commands.ForEach(x => x.Execute());
        }

        public void Undo()
        {
            commands.ForEach(x => x.Undo());
        }
    }
}
