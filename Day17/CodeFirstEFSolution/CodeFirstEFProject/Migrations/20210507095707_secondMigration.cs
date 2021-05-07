using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstEFProject.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerBillNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomer");
        }
    }
}
