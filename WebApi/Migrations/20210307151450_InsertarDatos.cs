using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InsertarDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Sectores(Nombre) Values('Rentas/inmobiliario')");
            migrationBuilder.Sql("INSERT INTO Sectores(Nombre) Values('Rentas/automotor')");
            migrationBuilder.Sql("INSERT INTO Sectores(Nombre) Values('Rentas/embarcaciones')");
            migrationBuilder.Sql("INSERT INTO Sectores(Nombre) Values('Medico')");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
