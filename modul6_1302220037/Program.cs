

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
            Random random = new Random();
            id = random.Next(10000, 100000);
            this.title = title;
            playCount = 0;
        }

        public void increasePlayCount(int playCount)
        {
            this.playCount = playCount++;
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
            Random random = new Random();
            id = random.Next(10000, 100000);

            this.username = username;
            uploadedVideos = new List<SayaTubeVideo>();
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
            uploadedVideos.Add(video);
        }
        public void PrintAllVideoPlayCount()
        {
            Console.WriteLine("User : " + this.username);
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
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