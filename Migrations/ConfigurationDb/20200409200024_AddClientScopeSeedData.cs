using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recordkeepidentityserver.Migrations.ConfigurationDb
{
    public partial class AddClientScopeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 20, 0, 23, 874, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "ApiSecrets",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 20, 0, 23, 850, DateTimeKind.Utc).AddTicks(1322));

            migrationBuilder.InsertData(
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { -2, -1, "openid" },
                    { -3, -1, "profile" }
                });

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 20, 0, 23, 664, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 20, 0, 23, 848, DateTimeKind.Utc).AddTicks(6230));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 19, 23, 32, 586, DateTimeKind.Utc).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "ApiSecrets",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 19, 23, 32, 562, DateTimeKind.Utc).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 19, 23, 32, 383, DateTimeKind.Utc).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 19, 23, 32, 560, DateTimeKind.Utc).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -2,
                column: "Created",
                value: new DateTime(2020, 4, 9, 19, 23, 32, 607, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 9, 19, 23, 32, 599, DateTimeKind.Utc).AddTicks(1273));
        }
    }
}
