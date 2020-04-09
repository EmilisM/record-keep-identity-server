using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recordkeepidentityserver.Migrations.ConfigurationDb
{
    public partial class AddIdentityResourceSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "IdentityResources",
                columns: new[]
                {
                    "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "NonEditable",
                    "Required", "ShowInDiscoveryDocument", "Updated"
                },
                values: new object[,]
                {
                    {
                        -1, new DateTime(2020, 4, 9, 19, 23, 32, 599, DateTimeKind.Utc).AddTicks(1273), null,
                        "Your user identifier", false, true, "openid", false, true, true, null
                    },
                    {
                        -2, new DateTime(2020, 4, 9, 19, 23, 32, 607, DateTimeKind.Utc).AddTicks(6237),
                        "Your user profile information (first name, last name, etc.)", "User profile", true, true,
                        "profile", false, false, true, null
                    }
                });

            migrationBuilder.InsertData(
                table: "IdentityClaims",
                columns: new[] {"Id", "IdentityResourceId", "Type"},
                values: new object[,]
                {
                    {-1, -1, "sub"},
                    {-2, -2, "name"},
                    {-3, -2, "family_name"},
                    {-4, -2, "given_name"},
                    {-5, -2, "middle_name"},
                    {-6, -2, "nickname"},
                    {-7, -2, "preferred_username"},
                    {-8, -2, "profile"},
                    {-9, -2, "picture"},
                    {-10, -2, "website"},
                    {-11, -2, "gender"},
                    {-12, -2, "birthdate"},
                    {-13, -2, "zoneinfo"},
                    {-14, -2, "locale"},
                    {-15, -2, "updated_at"}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "IdentityClaims",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 5, 16, 56, 44, 952, DateTimeKind.Utc).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "ApiSecrets",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 5, 16, 56, 44, 925, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 5, 16, 56, 44, 723, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1,
                column: "Created",
                value: new DateTime(2020, 4, 5, 16, 56, 44, 923, DateTimeKind.Utc).AddTicks(7971));
        }
    }
}