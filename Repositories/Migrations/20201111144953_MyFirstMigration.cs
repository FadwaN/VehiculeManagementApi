using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(maxLength: 100, nullable: true),
                    Nom = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Annee = table.Column<string>(maxLength: 100, nullable: true),
                    Couleur = table.Column<string>(maxLength: 100, nullable: true),
                    Prix = table.Column<double>(nullable: false),
                    Disponibilite = table.Column<bool>(nullable: false),
                    ModelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_ProductTypes_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Description", "Model" },
                values: new object[] { 1L, "Model 1 description", "Model1" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Description", "Model" },
                values: new object[] { 2L, "Model 2 description", "Model2" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Description", "Model" },
                values: new object[] { 3L, "Model 3 description", "Model3" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Annee", "Couleur", "Description", "Disponibilite", "Matricule", "ModelId", "Nom", "Prix" },
                values: new object[,]
                {
                    { 1L, "2016", "Rouge", "Description vehicule1", true, "1111111", 1L, "Vehicule1", 1100.0 },
                    { 2L, "2017", "Vert", "Description vehicule2", true, "2222222", 1L, "Vehicule2", 1200.0 },
                    { 3L, "2018", "Blanc", "Description vehicule3", true, "3333333", 2L, "Vehicule3", 1300.0 },
                    { 4L, "2019", "Rouge", "Description vehicule4", true, "4444444", 3L, "Vehicule4", 1400.0 },
                    { 5L, "2020", "Noir", "Description vehicule5", true, "5555555", 3L, "Vehicule5", 1500.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ModelId",
                table: "Categories",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
