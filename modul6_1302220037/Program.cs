

using System.Diagnostics;
using System.Diagnostics.Contracts;

internal class Program
{

    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;
        public int getPlayCount { get { return playCount; } }
        public string getTitle { get { return title; } }
        public SayaTubeVideo(string title)
        {
            Contract.Requires(title.Length < 100 || title != null);
            try
            {
                checked
                {
                    if (title == null)
                    {
                        throw new ArgumentNullException(nameof(title));
                    }
                    else if (title.Length > 100)
                    {
                        throw new ArgumentOutOfRangeException("Tidak Boleh Lebih Dari 100");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Random random = new Random();
            id = random.Next(10000, 100000);
            this.title = title;
            playCount = 0;
            Contract.Ensures(this.title.Length < 100 && title != null);
        }

        public void increasePlayCount(int playCount)
        {
            if (this.title != null)
            {
                Contract.Requires(!string.IsNullOrEmpty(this.title) && playCount<0);
                try
                {
                    checked
                    {
                        if (this.playCount + playCount > 25000000)
                        {
                            throw new OverflowException("Over dari 25.000.000");
                        }
                        this.playCount += playCount;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                Contract.Ensures(this.playCount < 25000000);
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("Video Details:");
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Play Count: " + playCount);
        }
    }

    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        private string username;

        public SayaTubeUser(string username)
        {
            Contract.Requires(username.Length < 100 || username != null);
            try
            {
                checked
                {
                    if (username == null)
                    {
                        throw new ArgumentNullException(nameof(username));
                    }
                    else if (username.Length > 100)
                    {
                        throw new ArgumentOutOfRangeException("Tidak Boleh Lebih Dari 100");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Random random = new Random();
            id = random.Next(10000, 100000);

            this.username = username;
            uploadedVideos = new List<SayaTubeVideo>();
            Contract.Ensures(this.username.Length < 100 && username != null);
        }

        public int getTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var item in uploadedVideos)
            {
                total = total + item.getPlayCount;
            }
            return total;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            Contract.Requires(video != null && video.getPlayCount < int.MaxValue);
            try
            {
                checked
                {
                    if (video == null && video.getPlayCount >= int.MaxValue)
                    {
                        throw new ArgumentNullException(nameof(video));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            uploadedVideos.Add(video);
        }
        public void PrintAllVideoPlayCount()
        {

            Console.WriteLine("User : " + this.username);
            for (int i = 0; i < uploadedVideos.Count || i < 8; i++)
            {
                try
                {
                    checked
                    {
                        if (i > 8)
                        {
                            throw new Exception("lebih dari 8");
                        }
                    }
                }
                SayaTubeVideo item = uploadedVideos[i];
                Console.WriteLine("Video " + (i + 1) + " " + item.getTitle);

            }
        }
    }

    static void Main(string[] args) { 
        SayaTubeUser user = new SayaTubeUser("Nizar Rasyiid");
        SayaTubeVideo vid = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid2 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid3 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid4 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid5 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid6 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid7 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid8 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid9 = new SayaTubeVideo("Tutorial Git");
        SayaTubeVideo vid10 = new SayaTubeVideo("Tutorial Git");
        user.AddVideo(vid);
        user.AddVideo(vid2);
        user.AddVideo(vid3);
        user.AddVideo(vid4);
        user.AddVideo(vid5);
        user.AddVideo(vid6);
        user.AddVideo(vid7);
        user.AddVideo(vid8);
        user.AddVideo(vid9);
        user.AddVideo(vid10);
        user.PrintAllVideoPlayCount();
    }
}