using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    public partial class editingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "b0f8a093-3e43-468b-a930-a7e6e5451087");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "bca100e1-2a6d-456c-85f8-f98183cba79b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a5847f48-234e-43fb-a9e1-ce25ff5711b7", "MAJIDRAD@HOTMAIL.COM", "AQAAAAEAACcQAAAAEL9Iwp/im8lkYyO/j1tDCSF9JoU9e1lR5lvsB2X7KxcMMWSdtYW7gS5hKK3QVB6o7w==", "176fc176-a7cb-44e0-ab71-a66c36566f21", "Majidrad@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8edd4c39-a9d5-4055-90ae-84276a828c4d", "TEST@TEST.COM", "AQAAAAEAACcQAAAAELwmg9sPospdRRvMe68H+/nr4VNEkCVQw89aSmy27s/iYjZkHbRct88DqOIwp1tqWA==", "370b268a-b307-4e34-8c85-5960ec4d5932", "test@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "fa5c7853-edc8-450a-8b51-6ee9efa3adcb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "acf0be35-4887-4048-909f-3199042b7891");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b541362c-8742-404b-adc4-389a8b77b460", null, "AQAAAAEAACcQAAAAEJ0m9SOBSSo2goAVjUB8lDY1XAlHCecqjYbQluj1tI+/PJLOcYDRRAGjKb56G5rqOw==", "10fe6706-3352-4c5e-888d-cf9293adeaa8", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d693dfed-9335-490c-ae64-6f6d504835b3", null, "AQAAAAEAACcQAAAAEGbUso7s3bTw0EsH3YUSEC4AqZAO4Bcq8hFaea/ouRPypWQB1i0/7wBco50EMcHmrA==", "3c524c2d-8861-4997-99c5-837d9c918309", null });
        }
    }
}
