using CAO.Blackjack.Core.Data;
using CAO.Blackjack.Core.Models;
using CAO.Blackjack.Core.Utils;
using CAO.Blackjack.Forms.Properties;
using CAO.Blackjack.Forms.Utils;
using System.Linq;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// The application's achievements form, used to view unlocked achievements.
    /// </summary>
    public partial class FormAchievements : Form
    {
        /// <summary>
        /// The internal game state.
        /// </summary>
        private GameState state = CommonUtils.CreateNewGameState();

        /// <summary>
        /// Instantiate a new achievements form.
        /// </summary>
        public FormAchievements()
        {
            InitializeComponent();
            this.EnableDoubleBuffered(true);
            LoadGameState();
            UpdateUI();
        }

        /// <summary>
        /// Load the game state.
        /// </summary>
        private void LoadGameState()
        {
            GameState? loadedState = CommonUtils.LoadGameSaveFile();
            CommonUtils.TryCopyGameStateToCurrentState(ref state, loadedState);
            state.PropertyChanged += State_PropertyChanged;
        }

        /// <summary>
        /// Handle a state property change.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void State_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            string? propName = e.PropertyName;

            if (propName == null)
            {
                return;
            }

            if (propName == nameof(state.UnlockedAchievementIds))
            {
                UpdateAchievementsUI();
            }
        }

        /// <summary>
        /// Update the tooltip UI.
        /// </summary>
        private void UpdateTooltipUI()
        {
            tipExit.SetToolTip(btnExit, Resources.TooltipExitShop);
        }

        /// <summary>
        /// Update the UI globally.
        /// </summary>
        private void UpdateUI()
        {
            Text = CommonUtils.GetTitle();

            UpdateAchievementsUI();
            UpdateTooltipUI();
        }

        /// <summary>
        /// Update the UI for the background.
        /// </summary>
        private void UpdateAchievementsUI()
        {
            IEnumerable<Achievement> achievements = AchievementUtils.Achievements;

            listAchievements.Items.Clear();
            listAchievements.Items.AddRange(achievements.Select(
                achievement => new ListViewItem(achievement.ToString())
                {
                    ForeColor = GetAchievementForeColor(achievement),
                    Tag = achievement.Id,
                }).ToArray()
            );

            int totalCount = achievements.Count();
            int unlockedCount = achievements.Count(x => x.IsUnlocked(state));

            var percentage = ((double)unlockedCount / (double)totalCount);

            lblProgressionValue.Text = $"{unlockedCount}/{totalCount} ({percentage:P1})";
        }

        /// <summary>
        /// Gets the fore color of a achievement depending on the game state.
        /// </summary>
        /// <param name="achievement">The achievement for which to get the fore color.</param>
        /// <returns>The fore color of the achievement.</returns>
        private Color GetAchievementForeColor(Achievement achievement)
        {
            return achievement.IsUnlocked(state)
                ? Color.White
                : Color.DarkGray;
        }

        /// <summary>
        /// Exit the achievements screen.
        /// </summary>
        private void ExitAchievements()
        {
            while (true)
            {
                if (AppSaveFileUtils.SaveGame(state) || !DialogUtils.ConfirmChoice(Resources.ConfirmRetrySaveQuestion))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Handle the click of the exit button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            Close();
        }

        /// <summary>
        /// Handle the achievements form closing (before it closes).
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void FormAchievements_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitAchievements();
        }

        /// <summary>
        /// Handles the change of the selected index in the achievement list.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void ListAchievements_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem? selectedItem = null;
            foreach (ListViewItem item in listAchievements.Items)
            {
                if (item.Selected)
                {
                    selectedItem = item;
                    break;
                }
            }

            if (selectedItem == null)
            {
                lblDescription.Visible = false;
                lblStatus.Visible = false;
                return;
            }

            AudioUtils.Play(AudioUtils.Sounds.SfxCard);

            Achievement? achievement = AchievementUtils.Achievements
                                                       .SingleOrDefault(x => x.Id == (string)selectedItem.Tag);

            if (achievement == null)
            {
                return;
            }

            string status = achievement.IsUnlocked(state)
                ? Resources.AchievementUnlocked
                : Resources.AchievementLocked;

            lblStatus.Text = $"{status} {achievement}";
            lblDescription.Text = $"- {achievement.Description}";
         
            lblStatus.Visible = true;
            lblDescription.Visible = true;
        }
    }
}
