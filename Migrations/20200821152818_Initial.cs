using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Overgave.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTypes",
                columns: table => new
                {
                    ACTypes = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    SubType = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTypes", x => x.ACTypes);
                });

            migrationBuilder.CreateTable(
                name: "ATA",
                columns: table => new
                {
                    ATA = table.Column<int>(type: "int", nullable: false),
                    AtaText = table.Column<string>(type: "nchar(25)", fixedLength: true, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATA_1", x => x.ATA);
                });

            migrationBuilder.CreateTable(
                name: "TS",
                columns: table => new
                {
                    KLMId = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Initial = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    B1 = table.Column<bool>(type: "bit", nullable: false),
                    B2 = table.Column<bool>(type: "bit", nullable: false),
                    Def737 = table.Column<bool>(type: "bit", nullable: false),
                    Def747 = table.Column<bool>(type: "bit", nullable: false),
                    Def777 = table.Column<bool>(type: "bit", nullable: false),
                    Def787 = table.Column<bool>(type: "bit", nullable: false),
                    DefA330 = table.Column<bool>(type: "bit", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    isReadOnly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TS", x => x.KLMId);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Registration = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    ACType = table.Column<long>(type: "bigint", nullable: false),
                    Effectifity = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Etops = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft_1", x => x.Registration);
                    table.ForeignKey(
                        name: "FK_Aircraft_ACTypes",
                        column: x => x.ACType,
                        principalTable: "ACTypes",
                        principalColumn: "ACTypes",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubAta",
                columns: table => new
                {
                    SubAta = table.Column<string>(type: "nchar(25)", fixedLength: true, maxLength: 25, nullable: false),
                    ATA = table.Column<int>(type: "int", nullable: false),
                    B737 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    B747 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    B777 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    B787 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    A330 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAta", x => x.SubAta);
                    table.ForeignKey(
                        name: "FK_SubAta_ATA",
                        column: x => x.ATA,
                        principalTable: "ATA",
                        principalColumn: "ATA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ACReg = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    ATA = table.Column<int>(type: "int", nullable: true),
                    SubAta = table.Column<string>(type: "nchar(25)", fixedLength: true, nullable: true),
                    Initiator = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    VakGroep = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Catagorie = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemStatus = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    AddToPrint = table.Column<bool>(type: "bit", nullable: false),
                    ActionReq = table.Column<bool>(type: "bit", nullable: false),
                    ETOPSAffected = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false, defaultValueSql: "((180))"),
                    orgId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Aircraft",
                        column: x => x.ACReg,
                        principalTable: "Aircraft",
                        principalColumn: "Registration",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_ATA",
                        column: x => x.ATA,
                        principalTable: "ATA",
                        principalColumn: "ATA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_SubAta",
                        column: x => x.SubAta,
                        principalTable: "SubAta",
                        principalColumn: "SubAta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_TS",
                        column: x => x.Initiator,
                        principalTable: "TS",
                        principalColumn: "KLMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    RaPn = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    SnVn = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    InOut = table.Column<bool>(type: "bit", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                    table.ForeignKey(
                        name: "FK_Parts_Items",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    RefType = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Reference = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_References_Items",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_ACType",
                table: "Aircraft",
                column: "ACType");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ACReg",
                table: "Items",
                column: "ACReg");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ATA",
                table: "Items",
                column: "ATA");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Initiator",
                table: "Items",
                column: "Initiator");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SubAta",
                table: "Items",
                column: "SubAta");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ItemId",
                table: "Parts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_References_ItemId",
                table: "References",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAta_ATA",
                table: "SubAta",
                column: "ATA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "SubAta");

            migrationBuilder.DropTable(
                name: "TS");

            migrationBuilder.DropTable(
                name: "ACTypes");

            migrationBuilder.DropTable(
                name: "ATA");
        }
    }
}
