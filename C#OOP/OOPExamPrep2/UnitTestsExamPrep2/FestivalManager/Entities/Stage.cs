namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage
	{
        private const string CanNotBeNullMessage = "Can not be null!";

        private readonly List<Song> Songs;
		private readonly List<Performer> performers;

        public Stage() //tested
        {
            this.Songs = new List<Song>();
            this.performers = new List<Performer>();
        }

        public IReadOnlyCollection<Performer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(Performer performer) //tested
        {
            this.ValidateNullValue(performer, nameof(performer), CanNotBeNullMessage);

            if (performer.Age < 18)
            {
                throw new ArgumentException("You can only add performers that are at least 18.");
            }

            this.performers.Add(performer);
        }

        public void AddSong(Song song)//tested
        {
            this.ValidateNullValue(song, nameof(song), CanNotBeNullMessage);

            if (song.Duration.TotalMinutes < 1)
            {
                throw new ArgumentException("You can only add songs that are longer than 1 minute.");
            }

            this.Songs.Add(song);
        }

        public string AddSongToPerformer(string songName, string performerName)//tested
        {
            this.ValidateNullValue(songName, nameof(songName), CanNotBeNullMessage);
            this.ValidateNullValue(performerName, nameof(performerName), CanNotBeNullMessage);

            var perfomer = this.GetPerformer(performerName);
            var song = this.GetSong(songName);

            perfomer.SongList.Add(song);

            return $"{song} will be performed by {perfomer}";
        }

        public string Play()
        {
            var songsCount = this.performers.Sum(p => p.SongList.Count());

            return $"{this.performers.Count} performers played {songsCount} songs";
        }

        private Performer GetPerformer(string performerName)//tested
        {
            var performer = this.Performers.FirstOrDefault(p => p.FullName == performerName);

            if (performer == null)
            {
                throw new ArgumentException("There is no performer with this name.");
            }

            return performer;
        }

        private Song GetSong(string songName)//tested
        {
            var song = this.Songs.FirstOrDefault(p => p.Name == songName);

            if (song==null)
            {
                throw new ArgumentException("There is no song with this name.");
            }

            return song;
        }

        private void ValidateNullValue(object variable, string variableName, string exceptionMessage) //tested
        {
            if (variable == null)
            {
                throw new ArgumentNullException(variableName, exceptionMessage);
            }
        }
    }
}
