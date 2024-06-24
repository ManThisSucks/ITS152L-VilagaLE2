using BlogDataLibrary.Models;

namespace BlogDataLibrary.Data
{
    public interface ISqlData
    {
        void AddPost(PostModel post);
        UserModel? Authenticate(string username, string password);
        void Register(string username, string firstName, string lastName, string password);
        public List<ListPostModel> ListPosts();
        ListPostModel? ShowPostDetails(int id);
    }
}