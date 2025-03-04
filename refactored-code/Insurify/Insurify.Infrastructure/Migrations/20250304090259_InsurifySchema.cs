using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurify.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InsurifySchema : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "t_customers",
            columns: table => new
            {
                cus_pk = table.Column<int>(type: "int", nullable: false),
                cus_firstname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                cus_lastname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                cus_email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                cus_state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                cus_postalcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                cus_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                cus_street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                HasSecurityCertificate = table.Column<bool>(type: "bit", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false),
                is_active = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_t_customers", x => x.cus_pk);
            });

        migrationBuilder.CreateTable(
            name: "t_insurances",
            columns: table => new
            {
                ins_pk = table.Column<int>(type: "int", nullable: false),
                ins_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                ins_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                ins_priceamount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                ins_pricecurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                is_active = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_t_insurances", x => x.ins_pk);
            });

        migrationBuilder.CreateTable(
            name: "t_insurancepolicies",
            columns: table => new
            {
                inp_pk = table.Column<int>(type: "int", nullable: false),
                inp_ins_id = table.Column<int>(type: "int", nullable: false),
                inp_cus_id = table.Column<int>(type: "int", nullable: false),
                StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                inp_insuredamount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                inp_insuredcurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                inp_feeamount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                inp_feecurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                Status = table.Column<int>(type: "int", nullable: false),
                is_active = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_t_insurancepolicies", x => x.inp_pk);
                table.ForeignKey(
                    name: "FK_t_insurancepolicies_t_customers_inp_cus_id",
                    column: x => x.inp_cus_id,
                    principalTable: "t_customers",
                    principalColumn: "cus_pk",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_t_insurancepolicies_t_insurances_inp_ins_id",
                    column: x => x.inp_ins_id,
                    principalTable: "t_insurances",
                    principalColumn: "ins_pk",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_t_customers_cus_email",
            table: "t_customers",
            column: "cus_email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_t_insurancepolicies_inp_cus_id",
            table: "t_insurancepolicies",
            column: "inp_cus_id");

        migrationBuilder.CreateIndex(
            name: "IX_t_insurancepolicies_inp_ins_id",
            table: "t_insurancepolicies",
            column: "inp_ins_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "t_insurancepolicies");

        migrationBuilder.DropTable(
            name: "t_customers");

        migrationBuilder.DropTable(
            name: "t_insurances");
    }
}
