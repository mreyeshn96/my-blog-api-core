using Microsoft.EntityFrameworkCore.Migrations;

namespace my_app_backend.Migrations
{
    public partial class create_categories_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("categories", builder => new
            {
                cat_id = builder.Column<int>(type: "serial"),
                cat_name = builder.Column<string>(type: "varchar"),
                created_at = builder.Column<string>(type: "timestamp", defaultValueSql:"current_timestamp"),
                updated_at = builder.Column<string>(type: "timestamp", defaultValueSql:"current_timestamp"),
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
