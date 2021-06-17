using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCoreOverview2.Migrations
{
    public partial class DeesDataForAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Authors values('Jan', 'Bon', 'Brussel')");
            migrationBuilder.Sql("insert into Authors values('Saif', 'Saif2', 'Hoeilaart')");
            migrationBuilder.Sql("insert into Authors values('Emre', 'Elagoz', 'Antwerpen')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
