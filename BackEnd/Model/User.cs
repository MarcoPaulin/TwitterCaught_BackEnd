namespace BackEnd.Model
{
    public class Users
    {
        int id_user { get; set; }
        public string username { get; set; }
        public string salt_lvl_user { get; set; }
        public string twitterusername { get; set; }
        public string password { get; set; }
    }

    public class tweet
    {
        int id { get; set; }
        public string description { get; set; }
        public string salt_lvl_tweet { get; set; }
        public string url { get; set; }
        public int user_id { get; set; }
        public int follower_id { get; set; }
    }

    public class followers
    {
        int id_followers { get; set; }
        public string is_follower { get; set; }
        public string salt_lvl_follower { get; set; }
        public string username { get; set; }
        public int user_id { get; set; }
    }


}
