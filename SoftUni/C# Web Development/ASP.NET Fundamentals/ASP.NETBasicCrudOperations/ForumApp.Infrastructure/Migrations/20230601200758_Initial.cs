using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForumApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Guid"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Title"),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Content")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("10dd04d8-999a-4e8a-87e0-f166a2606dbf"), "League of Legends is a team-based multiplayer online battle arena (MOBA) game. Choose unique champions, fight on diverse battlefields, and strategize with teammates to destroy the enemy Nexus. With a wide roster of champions, intense combat, and regular updates, LoL offers endless hours of strategic fun and competitive gameplay.", "League of Legends" },
                    { new Guid("28fb4356-8a4f-4c7b-82e6-427d1dbc3dd3"), "Enter the enchanting realm of World of Warcraft, where you embark on an epic journey through a meticulously crafted fantasy world. With boundless possibilities and a rich tapestry of lore, WoW immerses you in a vibrant universe teeming with diverse races, captivating landscapes, and legendary creatures.Choose from an array of distinct classes and professions, each offering unique abilities and playstyles, as you carve your path to greatness. Whether you prefer the stalwart might of a warrior, the arcane mastery of a mage, the cunning precision of a rogue, or the mystical healing powers of a priest, the choices are endless.Venture forth into vast continents, from the hauntingly beautiful forests of Teldrassil to the scorching deserts of Tanaris, and unravel a gripping narrative woven through countless quests and encounters. Engage in thrilling dungeons, challenging raids, and intense PvP battles that test your mettle and reward you with valuable loot.", "World of Warcraft" },
                    { new Guid("70e120e4-4c40-45bb-baed-dc0227e2d64e"), "Northgard is a captivating strategy game that transports players to a mythical Viking world. With its immersive gameplay and beautiful aesthetics, it offers a fresh take on the genre. Settling new lands, managing resources, and expanding your Viking clan's influence make for a compelling experience. The game strikes a balance between accessible mechanics and deep strategic depth, allowing both casual players and seasoned strategists to enjoy it. The evolving seasons and challenging events keep you on your toes, forcing you to adapt your strategies and overcome obstacles. The attention to detail in the visuals and sound design adds to the game's atmosphere, creating an engaging and immersive environment. Whether you prefer peaceful exploration or aggressive conquest, Northgard offers multiple paths to victory, providing replayability and keeping you engaged. The multiplayer mode allows you to compete or cooperate with friends, adding a social element to the experience. While the game could benefit from additional content and more variety in victory conditions, Northgard remains a solid and enjoyable strategy game that deserves a place in any gamer's library.", "Northgard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
