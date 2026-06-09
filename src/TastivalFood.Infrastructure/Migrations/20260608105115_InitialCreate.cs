using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TastivalFood.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    RestaurantName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    PopularityScore = table.Column<decimal>(type: "numeric", nullable: false),
                    IsAlcoholic = table.Column<bool>(type: "boolean", nullable: false),
                    IsHalal = table.Column<bool>(type: "boolean", nullable: false),
                    OriginId = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.CheckConstraint("CK_MenuItems_Calories", "\"Calories\" >= 0");
                    table.CheckConstraint("CK_MenuItems_PopularityScore", "\"PopularityScore\" >= 0 AND \"PopularityScore\" <= 5");
                    table.ForeignKey(
                        name: "FK_MenuItems_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Users_RestaurantOwnerId",
                        column: x => x.RestaurantOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRestaurantTypes",
                columns: table => new
                {
                    RestaurantTypesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRestaurantTypes", x => new { x.RestaurantTypesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserRestaurantTypes_RestaurantTypes_RestaurantTypesId",
                        column: x => x.RestaurantTypesId,
                        principalTable: "RestaurantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRestaurantTypes_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemAllergies",
                columns: table => new
                {
                    AllergiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemAllergies", x => new { x.AllergiesId, x.MenuItemsId });
                    table.ForeignKey(
                        name: "FK_MenuItemAllergies_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemAllergies_MenuItems_MenuItemsId",
                        column: x => x.MenuItemsId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemIngredients",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemIngredients", x => new { x.IngredientsId, x.MenuItemsId });
                    table.ForeignKey(
                        name: "FK_MenuItemIngredients_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemIngredients_MenuItems_MenuItemsId",
                        column: x => x.MenuItemsId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("c3000001-0000-4000-8000-000000000001"), "Gluten allergy", "Gluten" },
                    { new Guid("c3000001-0000-4000-8000-000000000002"), "Milk allergy", "Milk" },
                    { new Guid("c3000001-0000-4000-8000-000000000003"), "Peanut allergy", "Peanut" },
                    { new Guid("c3000001-0000-4000-8000-000000000004"), "Soy allergy", "Soy" },
                    { new Guid("c3000001-0000-4000-8000-000000000005"), "Egg allergy", "Egg" },
                    { new Guid("c3000001-0000-4000-8000-000000000006"), "Fish allergy", "Fish" },
                    { new Guid("c3000001-0000-4000-8000-000000000007"), "Shellfish allergy", "Shellfish" }
                });

            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { new Guid("b2000001-0000-4000-8000-000000000001"), "Iran" },
                    { new Guid("b2000001-0000-4000-8000-000000000002"), "Italy" },
                    { new Guid("b2000001-0000-4000-8000-000000000003"), "France" },
                    { new Guid("b2000001-0000-4000-8000-000000000004"), "Turkey" },
                    { new Guid("b2000001-0000-4000-8000-000000000005"), "Japan" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000001-0000-4000-8000-000000000001"), "Persian" },
                    { new Guid("a1000001-0000-4000-8000-000000000002"), "Italian" },
                    { new Guid("a1000001-0000-4000-8000-000000000003"), "Cafe" },
                    { new Guid("a1000001-0000-4000-8000-000000000004"), "FastFood" },
                    { new Guid("a1000001-0000-4000-8000-000000000005"), "Bakery" },
                    { new Guid("a1000001-0000-4000-8000-000000000006"), "Seafood" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemAllergies_MenuItemsId",
                table: "MenuItemAllergies",
                column: "MenuItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredients_MenuItemsId",
                table: "MenuItemIngredients",
                column: "MenuItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OriginId",
                table: "MenuItems",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantOwnerId",
                table: "MenuItems",
                column: "RestaurantOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRestaurantTypes_UsersId",
                table: "UserRestaurantTypes",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemAllergies");

            migrationBuilder.DropTable(
                name: "MenuItemIngredients");

            migrationBuilder.DropTable(
                name: "UserRestaurantTypes");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "RestaurantTypes");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
