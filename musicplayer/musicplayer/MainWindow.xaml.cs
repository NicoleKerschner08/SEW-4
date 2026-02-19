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
            view_start.Visibility = Visibility.Collapsed;
            view_addsong.Visibility = Visibility.Visible;
        }

        private void AddPlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            view_start.Visibility = Visibility.Collapsed;   
            view_addplaylist.Visibility = Visibility.Visible;

        }

        private void DeletePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            PlaylistListBox.Items.Remove(PlaylistListBox.SelectedItem);
        }

        private void DeleteSongButton_Click(object sender, RoutedEventArgs e)
        {
            SongsListBox.Items.Remove(SongsListBox.SelectedItem);
        }


        private void backToStartView_Click(object sender, RoutedEventArgs e)
        {
            view_addsong.Visibility = Visibility.Collapsed;
            view_start.Visibility = Visibility.Visible;
        }

        private void saveSong_Click(object sender, RoutedEventArgs e)
        {
            lied lied = new lied(TitleTextBox.Text, InterpretTextBox.Text, int.Parse(ReleaseYearTextBox.Text), AdditionalInfoTextBox.Text);
            view_addsong.Visibility = Visibility.Collapsed;
            view_start.Visibility = Visibility.Visible;
            SongsListBox.Items.Add(lied.ToString());
            songs.Add(lied);
        }

        private void backToStartViewPlaylist_Click(object sender, RoutedEventArgs e)
        {
            view_addplaylist.Visibility = Visibility.Collapsed;
            view_start.Visibility = Visibility.Visible;
        }

        private void savePlaylist_Click(object sender, RoutedEventArgs e)
        {
            playlist playlist = new playlist(txtbox_playlistname.Text);
            view_start.Visibility = Visibility.Visible;
            view_addplaylist.Visibility = Visibility.Collapsed;
            PlaylistListBox.Items.Add(playlist.ToString());
            playlists.Add(playlist);
        }

        private void ShowPlaylistContent_Click(object sender, RoutedEventArgs e)
        {
            view_start.Visibility = Visibility.Collapsed;   
            view_playlist.Visibility = Visibility.Visible;
            ListBox_playlistContent.Items.Clear();
            string selectedName = (string)PlaylistListBox.SelectedItem;
            foreach(playlist playlist in playlists)
            {
                if(playlist.name == selectedName)
                {
                    foreach(lied song in playlist.songs)
                    {
                        ListBox_playlistContent.Items.Add(song.ToString());
                    }
                }
            }
            txtblock_playlistname_asTitle.Text = selectedName;
        }

        private void add_song_to_playlist_Click(object sender, RoutedEventArgs e)
        {
            view_playlist.Visibility = Visibility.Collapsed;
            view_selectSong.Visibility = Visibility.Visible;
            foreach(lied song in songs)
            {
                ListBox_ShowSongs.Items.Add(song.ToString());
            }
        }

        private void delete_song_from_playlist_Click(object sender, RoutedEventArgs e)
        {
            string selectedName = (string)ListBox_ShowSongs.SelectedItem;
            ListBox_playlistContent.Items.Remove(ListBox_playlistContent.SelectedItem);
            foreach (lied song in songs)
            {
                if (song.ToString() == selectedName)
                {
                    foreach (playlist playlist in playlists)
                    {
                        if (playlist.name == txtblock_playlistname_asTitle.Text)
                        {
                            playlist.songs.Remove(song);
                        }
                    }
                }

            }
        }

        private void backToStartViewShowSongs(object sender, RoutedEventArgs e)
        {
            view_selectSong.Visibility = Visibility.Collapsed;
            view_playlist.Visibility = Visibility.Visible;
        }

        private void saveSongToPlaylist(object sender, RoutedEventArgs e)
        {
            view_selectSong.Visibility = Visibility.Collapsed;
            view_playlist.Visibility = Visibility.Visible;
            string selectedName = (string)ListBox_ShowSongs.SelectedItem;
            foreach (lied song in songs)
            {
                if (song.ToString() == selectedName)
                {
                    ListBox_playlistContent.Items.Add(song.ToString());
                    foreach(playlist playlist in playlists)
                    {
                        if(playlist.name == txtblock_playlistname_asTitle.Text)
                        {
                            playlist.songs.Add(song);
                        }
                    }
                }

            }
            ListBox_ShowSongs.Items.Clear();
        }

        private void backToStartViewPlaylistContent(object sender, RoutedEventArgs e)
        {
            view_playlist.Visibility= Visibility.Collapsed;
            view_start.Visibility = Visibility.Visible;
        }
    }

}
