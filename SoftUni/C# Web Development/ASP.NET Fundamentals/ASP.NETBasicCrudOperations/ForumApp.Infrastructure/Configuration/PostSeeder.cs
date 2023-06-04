namespace ForumApp.Infrastructure.Configuration
{
    using ForumApp.Infrastructure.Models;

    internal class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new List<Post>();

            Post currentPost;

            currentPost = new Post()
            {
                Title = "World of Warcraft",

                Content = "Enter the enchanting realm of World of Warcraft, where you embark on an epic journey through a meticulously crafted fantasy world. With boundless possibilities and a rich tapestry of lore, WoW immerses you in a vibrant universe teeming with diverse races, captivating landscapes, and legendary creatures.Choose from an array of distinct classes and professions, each offering unique abilities and playstyles, as you carve your path to greatness. Whether you prefer the stalwart might of a warrior, the arcane mastery of a mage, the cunning precision of a rogue, or the mystical healing powers of a priest, the choices are endless.Venture forth into vast continents, from the hauntingly beautiful forests of Teldrassil to the scorching deserts of Tanaris, and unravel a gripping narrative woven through countless quests and encounters. Engage in thrilling dungeons, challenging raids, and intense PvP battles that test your mettle and reward you with valuable loot."
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "League of Legends",
                Content = "League of Legends is a team-based multiplayer online battle arena (MOBA) game. Choose unique champions, fight on diverse battlefields, and strategize with teammates to destroy the enemy Nexus. With a wide roster of champions, intense combat, and regular updates, LoL offers endless hours of strategic fun and competitive gameplay."
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "Northgard",

                Content = "Northgard is a captivating strategy game that transports players to a mythical Viking world. With its immersive gameplay and beautiful aesthetics, it offers a fresh take on the genre. Settling new lands, managing resources, and expanding your Viking clan's influence make for a compelling experience. The game strikes a balance between accessible mechanics and deep strategic depth, allowing both casual players and seasoned strategists to enjoy it. The evolving seasons and challenging events keep you on your toes, forcing you to adapt your strategies and overcome obstacles. The attention to detail in the visuals and sound design adds to the game's atmosphere, creating an engaging and immersive environment. Whether you prefer peaceful exploration or aggressive conquest, Northgard offers multiple paths to victory, providing replayability and keeping you engaged. The multiplayer mode allows you to compete or cooperate with friends, adding a social element to the experience. While the game could benefit from additional content and more variety in victory conditions, Northgard remains a solid and enjoyable strategy game that deserves a place in any gamer's library."
            };

            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
