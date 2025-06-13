using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SRwebMVC.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationRecipeSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PrepTime = table.Column<int>(type: "integer", nullable: false),
                    CookTime = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => new { x.RecipeId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    QuantityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Quantities_QuantityId",
                        column: x => x.QuantityId,
                        principalTable: "Quantities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    StepNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lunch" },
                    { 2, "Side" },
                    { 3, "Dinner" },
                    { 4, "Beef" },
                    { 5, "No Cook" },
                    { 6, "Stove Top" },
                    { 7, "One Pot" },
                    { 8, "Oven" },
                    { 9, "Cast Iron" },
                    { 10, "Barbeque" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bread" },
                    { 2, "Ham" },
                    { 3, "Cheese" },
                    { 4, "Rice" },
                    { 5, "Water" },
                    { 6, "Salt" },
                    { 7, "Steak" },
                    { 8, "Pepper" },
                    { 9, "Oil" }
                });

            migrationBuilder.InsertData(
                table: "Quantities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Slices" },
                    { 2, "Grams" },
                    { 3, "Cups" },
                    { 4, "Tablespoons" },
                    { 5, "Teaspoons" },
                    { 6, "Pieces" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookTime", "Name", "PrepTime" },
                values: new object[,]
                {
                    { 1, 3, "Ham and Cheese Sandwich", 5 },
                    { 2, 20, "Stovetop Rice", 2 },
                    { 3, 40, "Forward Sear Steak", 10 }
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "CategoryId", "RecipeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Amount", "QuantityId" },
                values: new object[,]
                {
                    { 1, 1, 2.0m, 1 },
                    { 2, 1, 50.0m, 2 },
                    { 3, 1, 30.0m, 2 },
                    { 4, 2, 1.0m, 3 },
                    { 5, 2, 2.0m, 3 },
                    { 6, 2, 0.5m, 5 },
                    { 6, 3, 0.5m, 5 },
                    { 7, 3, 1.0m, 6 },
                    { 8, 3, 0.25m, 5 },
                    { 9, 3, 1.0m, 4 }
                });

            migrationBuilder.InsertData(
                table: "RecipeSteps",
                columns: new[] { "Id", "Description", "RecipeId", "StepNumber" },
                values: new object[,]
                {
                    { 1, "Lay out two slices of bread.", 1, 1 },
                    { 2, "Place ham on one slice of bread.", 1, 2 },
                    { 3, "Add cheese on top of the ham.", 1, 3 },
                    { 4, "Top with the second slice of bread.", 1, 4 },
                    { 5, "Toast the sandwich if desired.", 1, 5 },
                    { 6, "Rinse the rice under cold water.", 2, 1 },
                    { 7, "Add rice, water, and salt to a pot.", 2, 2 },
                    { 8, "Bring to a boil over high heat.", 2, 3 },
                    { 9, "Reduce heat to low, cover, and simmer until water is absorbed.", 2, 4 },
                    { 10, "Remove from heat and let stand covered for 5 minutes before serving.", 2, 5 },
                    { 11, "Preheat oven to 250°F (120°C).", 3, 1 },
                    { 12, "Season steak with salt and pepper.", 3, 2 },
                    { 13, "Place steak on a wire rack over a baking sheet.", 3, 3 },
                    { 14, "Roast in oven until desired internal temperature is reached.", 3, 4 },
                    { 15, "Heat oil in a cast iron skillet over high heat.", 3, 5 },
                    { 16, "Sear steak on both sides until a brown crust forms.", 3, 6 },
                    { 17, "Rest steak for 5 minutes before slicing and serving.", 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_QuantityId",
                table: "RecipeIngredients",
                column: "QuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeSteps");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Quantities");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
