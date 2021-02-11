using System.Windows;

namespace TicTacToe
{
    public partial class Menu : Window
    {
        private bool IsComputer;
        
        public Menu()
        {
            InitializeComponent();
        }
        
        private void Button_Action_Player(object sender, RoutedEventArgs e)
        {
            IsComputer = false;
            CreateGame(IsComputer);
            this.Close();
        }
        
        private void Button_Action_Computer(object sender, RoutedEventArgs e)
        {
            IsComputer = true;
            CreateGame(IsComputer);
            this.Close();
        }

        private void CreateGame(bool isComputer)
        {
            Game game = new Game(isComputer);
            game.Show();
        }
    }
}