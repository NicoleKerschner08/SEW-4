    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    namespace musicplayer
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            List<playlist> playlists = new List<playlist>();
            List<lied> songs = new List<lied>();
            public MainWindow()
            {
                InitializeComponent();
            }

            private void AddSongButton_Click(object sender, RoutedEventArgs e)
            {
                SwitchView(view_start, view_addsong);
            }

            private void AddPlaylistButton_Click(object sender, RoutedEventArgs e)
            {
                SwitchView(view_start, view_addplaylist);

            }

            private void DeletePlaylistButton_Click(object sender, RoutedEventArgs e)
            {
                PlaylistListBox.Items.Remove(PlaylistListBox.SelectedItem);
            }

            private void DeleteSongButton_Click(object sender, RoutedEventArgs e)
            {
                songs.Remove(FindSongByDisplayName(SongsListBox.SelectedItem.ToString()));
                SongsListBox.Items.Remove(SongsListBox.SelectedItem);   
            }

            private void backToStartView_Click(object sender, RoutedEventArgs e)
            {
                SwitchView(view_addsong, view_start);
            }

            private void saveSong_Click(object sender, RoutedEventArgs e)
            {
                lied lied = new lied(TitleTextBox.Text, InterpretTextBox.Text, int.Parse(ReleaseYearTextBox.Text), AdditionalInfoTextBox.Text);
                SwitchView(view_addsong, view_start);
                SongsListBox.Items.Add(lied.ToString());
                songs.Add(lied);
            }

            private void backToStartViewPlaylist_Click(object sender, RoutedEventArgs e)
            {
                SwitchView(view_addplaylist, view_start);
            }

            private void savePlaylist_Click(object sender, RoutedEventArgs e)
            {
                playlist playlist = new playlist(txtbox_playlistname.Text);
                SwitchView(view_addplaylist, view_start);
                PlaylistListBox.Items.Add(playlist.ToString());
                playlists.Add(playlist);
            }

            private void ShowPlaylistContent_Click(object sender, RoutedEventArgs e)
            {
                SwitchView(view_start, view_playlist);
                ListBox_playlistContent.Items.Clear();
                string selectedName = (string)PlaylistListBox.SelectedItem;
                playlist playlist = FindPlaylistByName(selectedName);
                   foreach(lied song in playlist.songs)
                   {
                        ListBox_playlistContent.Items.Add(song.ToString());
                   }
                           
                txtblock_playlistname_asTitle.Text = selectedName;
            }

            private void add_song_to_playlist_Click(object sender, RoutedEventArgs e)
            {
                SwitchView(view_playlist, view_selectSong);
                ListBox_ShowSongs.Items.Clear();
                foreach (lied song in songs)
                {
                    ListBox_ShowSongs.Items.Add(song.ToString());
                }
            }

            private void delete_song_from_playlist_Click(object sender, RoutedEventArgs e)
            {
                string selectedName = (string)ListBox_playlistContent.SelectedItem;
                ListBox_playlistContent.Items.Remove(ListBox_playlistContent.SelectedItem);
                lied song = FindSongByDisplayName(selectedName);
                playlist playlist = FindPlaylistByName(txtblock_playlistname_asTitle.Text);
                playlist.songs.Remove(song);
            }

            private void backToStartViewShowSongs(object sender, RoutedEventArgs e)
            {
                SwitchView(view_selectSong, view_playlist);
            }

            private void saveSongToPlaylist(object sender, RoutedEventArgs e)
            {
                SwitchView(view_selectSong, view_playlist);
                string selectedName = (string)ListBox_ShowSongs.SelectedItem;
                lied song = FindSongByDisplayName(selectedName);
                ListBox_playlistContent.Items.Add(song.ToString());
                playlist playlist = FindPlaylistByName(txtblock_playlistname_asTitle.Text);
                playlist.songs.Add(song);
                ListBox_ShowSongs.Items.Clear();
            }

            private void backToStartViewPlaylistContent(object sender, RoutedEventArgs e)
            {
                SwitchView(view_playlist, view_start);
            }

            private void SwitchView(UIElement hide, UIElement show)
            {
                hide.Visibility = Visibility.Collapsed;
                show.Visibility = Visibility.Visible;
            }

            private playlist FindPlaylistByName(string name)
            {
                foreach (playlist pl in playlists)
                    if (pl.name == name)
                        return pl;

                return null;
            }

            private lied FindSongByDisplayName(string name)
            {
                foreach (lied song in songs)
                    if (song.ToString() == name)
                        return song;

                return null;
            }

        private void onClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void saveSongs()
        {
            foreach (lied song in songs)
            {

            }
        }
    }
}
