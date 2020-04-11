using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recordkeepidentityserver.Migrations.ConfigurationDb
{
    public partial class RemoveClientAndApiSecret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApiSecrets",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 11, 18, 30, 47, 879, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] {"AllowAccessTokensViaBrowser", "Created", "RequireClientSecret"},
                values: new object[]
                    {true, new DateTime(2020, 4, 11, 18, 30, 47, 851, DateTimeKind.Utc).AddTicks(9739), false});

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -2,
                column: "Created",
                value: new DateTime(2020, 4, 11, 18, 30, 47, 900, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 11, 18, 30, 47, 892, DateTimeKind.Utc).AddTicks(2959));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 20, 0, 23, 874, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.InsertData(
                table: "ApiSecrets",
                columns: new[] {"Id", "ApiResourceId", "Created", "Description", "Expiration", "Type", "Value"},
                values: new object[]
                {
                    -1, -1, new DateTime(2020, 4, 9, 20, 0, 23, 850, DateTimeKind.Utc).AddTicks(1322), null, null,
                    "SharedSecret", "Af+niBFGH0GtZCGHxrt4l9TIZhA4SIfuHDVQpyo4kUA="
                });

            migrationBuilder.InsertData(
                table: "ClientSecrets",
                columns: new[] {"Id", "ClientId", "Created", "Description", "Expiration", "Type", "Value"},
                values: new object[]
                {
                    -1, -1, new DateTime(2020, 4, 9, 20, 0, 23, 664, DateTimeKind.Utc).AddTicks(5696), null, null,
                    "SharedSecret", "SVMh3ARiDOtiprKv7cae7dAiGypszDwfNyrdP6ccW5k="
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] {"AllowAccessTokensViaBrowser", "Created", "RequireClientSecret"},
                values: new object[]
                    {false, new DateTime(2020, 4, 9, 20, 0, 23, 848, DateTimeKind.Utc).AddTicks(6230), true});

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -2,
                column: "Created",
                value: new DateTime(2020, 4, 9, 20, 0, 23, 895, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 20, 0, 23, 887, DateTimeKind.Utc).AddTicks(4300));
        }
    }
}