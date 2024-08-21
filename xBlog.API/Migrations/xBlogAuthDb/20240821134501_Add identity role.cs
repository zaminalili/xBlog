using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xBlog.API.Migrations.xBlogAuthDb
{
    /// <inheritdoc />
    public partial class Addidentityrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "701ebc88-0ad0-4924-8794-444db4a49917", "701ebc88-0ad0-4924-8794-444db4a49917", "Writer", "WRİTER" },
                    { "7e6e40ec-0e1c-472d-b24f-08a1a56a2c98", "7e6e40ec-0e1c-472d-b24f-08a1a56a2c98", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "701ebc88-0ad0-4924-8794-444db4a49917");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e6e40ec-0e1c-472d-b24f-08a1a56a2c98");
        }
    }
}
