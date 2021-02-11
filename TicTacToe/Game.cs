using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class Game
    {
        #region DATA

        private bool _playerTurn;
        public Player Player { get; private set; }
        public Player Enemy { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор с передаваемым значением против компьютера ли игра
        /// </summary>
        /// <param name="isComputer"></param>
        public Game(bool isComputer)
        {
            InitializeComponent();

            Random rand = new Random();
            Player = new Player(MarkType.Cross, ref Container);
            if (!isComputer)
            {
                Enemy = new Player(MarkType.Nought, ref Container);
                _playerTurn = rand.Next(2) == 0;
            }
            else
            {
                _playerTurn = true;
                //полиморфизм, тк объявлен Player, а создаём Computer
                Enemy = new Computer(MarkType.Nought, ref Container);
            }
        }

        /// <summary>
        /// Пустой кнструктор
        /// </summary>
        public Game() : this(true) {}

        #endregion

        #region Gameplay

        /// <summary>
        /// Если нажали на клетку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) => DoTurn(ref sender);

        /// <summary>
        /// Очередной игрок делает ход
        /// </summary>
        /// <param name="button"></param>
        private void DoTurn(ref object button)
        {
            //единственное летающее млекопитающее
            bool gibbon;
            var clicked = (Button) button;
            if (_playerTurn)
                gibbon = Player.DoTurn(ref clicked);
            else
                gibbon = Enemy.DoTurn(ref clicked);

            if (!gibbon)
                return;

            if (Enemy is Computer)
                Enemy.DoTurn(ref clicked);
            else
                _playerTurn = !_playerTurn;

            if (IsOver())
            {
                MessageBox.Show($"Winner is {(_playerTurn ? "player (X)" : "enemy (O)")}");

                Results resWindow = new Results(this);
                resWindow.Show();
                this.Close();
            }
        }

        private bool IsOver()
        {
            if (Player.IsLost())
            {
                _playerTurn = true;
                return true;
            }

            if (Enemy.IsLost())
            {
                _playerTurn = false;
                return true;
            }

            return false;
        }

        #endregion
    }
}