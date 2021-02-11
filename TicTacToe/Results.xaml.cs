using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class Results : Window
    {
        public Results(Game game)
        {
            InitializeComponent();

            TextBox playerScore = PlayerScore;
            TextBox enemyScore = EnemyScore;

            playerScore.Text = "Player turns: \n";
            game.Player.Turns.ForEach(turn => playerScore.Text += turn.ToString() + "\n");
            enemyScore.Text = "Enemy turns: \n";
            game.Enemy.Turns.ForEach(turn => enemyScore.Text += turn.ToString() + "\n");
        }

        private void Button_Action_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void Button_Action_NewGame(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}