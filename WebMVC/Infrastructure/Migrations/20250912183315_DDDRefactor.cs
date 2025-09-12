using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class DDDRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Quantities_QuantityId",
                table: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Quantities");

            migrationBuilder.DropTable(
                name: "RecipeSteps");

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "PrepTime",
                table: "Recipes",
                newName: "Servings");

            migrationBuilder.RenameColumn(
                name: "CookTime",
                table: "Recipes",
                newName: "PrepTimeMinutes");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "RecipeIngredients",
                newName: "Measurement_Amount");

            migrationBuilder.RenameColumn(
                name: "QuantityId",
                table: "RecipeIngredients",
                newName: "Measurement_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_QuantityId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_Measurement_UnitId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CookTimeMinutes",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Measurement_Amount",
                table: "RecipeIngredients",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    StepNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructions_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instructions",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Units_Measurement_UnitId",
                table: "RecipeIngredients",
                column: "Measurement_UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Units_Measurement_UnitId",
                table: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropColumn(
                name: "CookTimeMinutes",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "Servings",
                table: "Recipes",
                newName: "PrepTime");

            migrationBuilder.RenameColumn(
                name: "PrepTimeMinutes",
                table: "Recipes",
                newName: "CookTime");

            migrationBuilder.RenameColumn(
                name: "Measurement_Amount",
                table: "RecipeIngredients",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Measurement_UnitId",
                table: "RecipeIngredients",
                newName: "QuantityId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_Measurement_UnitId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_QuantityId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "RecipeIngredients",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

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
                name: "RecipeSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StepNumber = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_RecipeSteps_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Quantities_QuantityId",
                table: "RecipeIngredients",
                column: "QuantityId",
                principalTable: "Quantities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
